pro svm_classify,method,infile,outfile,shapefile,thresh,penalty,kernel_type,kernel_degree,kernel_bias
compile_opt idl2
  CATCH, Error_status
  IF Error_status NE 0 THEN BEGIN
    tmp = DIALOG_MESSAGE(errorshow+STRING(13b)+$
    !ERROR_STATE.MSG,/error,title = '������ʾ!')
    return
  ENDIF
  ENVI, /restore_base_save_files
  ENVI_BATCH_INIT
 ; infile = "D:\Trainning\002.tif"
  ;��������Ԥ����
  ENVI_OPEN_FILE, infile, r_fid=fid
  IF (fid EQ -1) THEN BEGIN
    RETURN
  ENDIF
  ;��ȡ�ļ���Ϣ
  ENVI_FILE_QUERY, fid, dims=dims, nb=nb,ns=ns,nl=nl
  pos  = LINDGEN(nb)
 ;���Ӱ�������ϵͳ
  proj = ENVI_GET_PROJECTION(fid = fid)
  ;outfile = "C:\kkk"
  ;shapefile='D:\Trainning\ROI.shp'
  ;singleValue = 3
  ;��ȡͶӰ��Ϣ�����ɴ˴���ͶӰ�ļ�
  n = strlen(shapefile)-3
  strput,shapefile,"prj",n
  openr,lun,shapefile,/get_lun
  shpPrjString=''
  readf,lun,shpPrjString
  free_lun,lun
  shapfeProjection=envi_proj_create(pe_coord_sys_str=shpPrjString)
  
  ;��shp�ļ�
  ;shapefile='D:\Trainning\ROI.shp'
  ;��ȡshp�ļ�����Ϣ
  strput,shapefile,"shp",n
  oshp=OBJ_NEW('IDLffShape',shapefile)
  oshp->getproperty,n_entities=n_ent,Attribute_info=attr_info,n_attributes=n_attr,Entity_type=ent_type
  ;��ʵ��
  FOR i=0,n_ent-1 do begin ;ѭ��
  ent=oshp->getentity(i) ;��ȡ��i��ʵ��
  ;���ʵ��ĵ�����
  vert=*(ent.vertices) ;ʵ��Ķ���
  ;�����Լ�¼
  attr=oshp->GetAttributes(i) ;��ȡ��k����¼
  ;�������ֶεļ�¼
  attrName = attr.(1)
  attColor = attr.(2)
  CASE attColor OF
  '255,0,0': BEGIN
  color = 2
  END
  '0,255,0': BEGIN
  color = 3
  END
  '0,0,255': BEGIN
  color = 4
  END
  '255,255,0': BEGIN
  color = 5
  END
  '0,255,255': BEGIN
  color = 6
  END
  '255,0,255': BEGIN
  color = 7
  END
  '176,48,96': BEGIN
  color = 8
  END
  '46,139,87': BEGIN
  color = 9
  END
  '160,32,240': BEGIN
  color = 10
  END
  '255,127,80': BEGIN
  color = 11
  END
  '127,255,212': BEGIN
  color = 12
  END
  '218,112,214': BEGIN
  color = 13
  END
  '160,82,45': BEGIN
  color = 14
  END
  '127,255,0': BEGIN
  color = 15
  END
  '216,191,216': BEGIN
  color = 16
  END
  endcase
  roi_id=envi_create_roi(ns=ns, nl=nl,color=color, name=attrName)
  ENVI_CONVERT_PROJECTION_COORDINATES, reform(vert[0,*]), reform(vert[1,*]),shapfeProjection,oxmap, oymap, proj
  ENVI_CONVERT_FILE_COORDINATES, fid, x_file_coords,y_file_coords, oxmap, oymap ;������ת�����ļ�ͶӰ
  envi_define_roi, roi_id, /POLYGON,xpts=x_file_coords,ypts=y_file_coords
  envi_save_rois,attrName,roi_id
  endfor
  Obj_destroy,oshp

  roi_ids = ENVI_GET_ROI_IDS(fid=fid,roi_colors=roi_colors, roi_names=class_names,nl=nl,ns=ns)
  ;��������������ı�
  IF ~KEYWORD_SET(thresh) THEN thresh = .5
  IF ~KEYWORD_SET(penalty) THEN penalty=75
  out_name = outputfile + ".dat"
  CASE kernel_type OF
  0: BEGIN
  envi_doit, 'envi_svm_doit',fid=fid, pos=pos, dims=dims, $
        out_name=out_name,roi_ids=roi_ids, thresh=thresh, $
        penalty=penalty, kernel_type= 0
  END
  1: BEGIN
  kernel_degree = kernel_degree
  kernel_bias = kernel_bias
  
  envi_doit, 'envi_svm_doit',fid=fid, pos=pos, dims=dims, $
        out_name=out_name,roi_ids=roi_ids, thresh=thresh, $
        penalty=penalty, kernel_type= 1, $
        kernel_degree=kernel_degree, kernel_bias=kernel_bias
  END
  2: BEGIN
  envi_doit, 'envi_svm_doit',fid=fid, pos=pos, dims=dims, $
        out_name=out_name,roi_ids=roi_ids, thresh=thresh, $
        penalty=penalty, kernel_type= 2
  END
  3: BEGIN
  kernel_bias = kernel_bias
   envi_doit, 'envi_svm_doit',fid=fid, pos=pos, dims=dims, $
        out_name=out_name,roi_ids=roi_ids, thresh=thresh, $
        penalty=penalty, kernel_type= 3, kernel_bias=kernel_bias
  END
  endcase
  
  
  
  
  
end