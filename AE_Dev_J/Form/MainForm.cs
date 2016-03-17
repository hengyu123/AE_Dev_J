using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Helpers;
using System.IO;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.CartoUI;
using AE_Dev_J.Form;
using ESRI.ArcGIS.Display;


namespace AE_Dev_J
{
    public partial class MainForm : XtraForm
    {
        public AxTOCControl getTocControl() { return m_tocControl; }
        public AxMapControl getMapControl() { return m_mapControl; }

        public MainForm()
        {
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop); // ESRI license
            InitializeComponent();
            InitSkinGallery();
        }

        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        #region Home 菜单事件

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        // ===== Project =====
        /// <summary>
        /// 打开工程文件，*.mxd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iOpenProject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            
            openDialog.Title = "打开工程";
            openDialog.Filter = "project files(*.mxd)|*.mxd";
            openDialog.Multiselect = false;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openDialog.FileName;
                m_mapControl.LoadMxFile(filename);
            }         
        }

        /// <summary>
        /// 关闭工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iCloseProject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        /// <summary>
        /// 保存工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iSaveProject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        /// <summary>
        /// 建立新工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iNewProject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        // ====== File ======
        /// <summary>
        /// 添加数据文件, *.shp or image data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iAddData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.Title = "打开文件";
            openDialog.Multiselect = true;
            openDialog.Filter = "shape files(*.shp)|*.shp|image files(*.img,*.tif,*.tiff,*.dat)|*.img;*.tif;*.tiff;*.dat";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < openDialog.FileNames.Count(); i++)
                {
                    string filename = openDialog.FileNames[i];
                    FileInfo finfo = new FileInfo(filename);
                    switch (finfo.Extension)
                    {
                        case ".shp":
                            m_mapControl.AddShapeFile(finfo.DirectoryName, finfo.Name);
                            break;

                        case ".dat":
                        case ".tif":
                        case ".tiff":
                        case ".ntf":
                        case ".img":
                            openRasterFile(filename);
                            break;

                        default:
                            break;
                    } // end switch
                } // end for
            } // end if
        }
        
        #endregion
        
        #region Process 菜单事件
        /// <summary>
        /// RGB自动分割
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iRgbSeg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RgbSegForm rgbForm = new RgbSegForm();
            rgbForm.Show();
        }

        /// <summary>
        /// 分类，点击弹出分类面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iClassification_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClassificationForm classForm = new ClassificationForm();
            classForm.Show();
        }
        #endregion

        #region m_tocControl右键菜单项
        /// <summary>
        /// 打开属性表右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openAttTable_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IBasicMap map = null;
            ILayer layer = null;
            object unk = null;
            object data = null;
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
            m_tocControl.GetSelectedItem(ref item, ref map, ref layer, ref unk, ref data);
            
            IFeatureLayer selectedLayer = layer as IFeatureLayer;
            if (item == esriTOCControlItem.esriTOCControlItemLayer && selectedLayer != null)
            {
                if (selectedLayer.DataSourceType == "Shapefile Feature Class")
                {   // 打开属性表窗口
                    AttributeTableForm attForm = new AttributeTableForm(selectedLayer, this);
                    attForm.Show();
                }
            }
        }

        /// <summary>
        /// 移除图层右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeLayer_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IBasicMap map = null;
            ILayer selectedLayer = null;
            object unk = null;
            object data = null;
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
            m_tocControl.GetSelectedItem(ref item, ref map, ref selectedLayer, ref unk, ref data);

            if (item == esriTOCControlItem.esriTOCControlItemLayer)
            {
                m_mapControl.Map.DeleteLayer(selectedLayer);
            }
        }

        /// <summary>
        /// 缩放至图层所在范围右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zoomToLayer_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IBasicMap map = null;
            ILayer selectedLayer = null;
            object unk = null;
            object data = null;
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
            m_tocControl.GetSelectedItem(ref item, ref map, ref selectedLayer, ref unk, ref data);
            
            if (item == esriTOCControlItem.esriTOCControlItemLayer)
            {
                m_mapControl.ActiveView.Extent = selectedLayer.AreaOfInterest;
                m_mapControl.ActiveView.Refresh();                
            }
        }
        #endregion

        #region tocControl鼠标事件
        /// <summary>
        /// tocControl鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_tocControl_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap map = null;
            ILayer layer = null;
            object index = null;
            object other = null;
            m_tocControl.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);

            if (e.button == 2) // 鼠标右键
            {
                switch (item)
                {
                    case esriTOCControlItem.esriTOCControlItemMap:  // 点击的是地图
                        tocControl_contextMenuStrip.Show(m_tocControl, new Point(e.x, e.y));
                        break;
                    case esriTOCControlItem.esriTOCControlItemLayer:    // 点击的是图层
                        tocControlLayer_ContextMenu.Show(m_tocControl, new Point(e.x, e.y));
                        break;
                    case esriTOCControlItem.esriTOCControlItemHeading:
                        break;
                    default:
                        tocControl_contextMenuStrip.Show(m_tocControl, new Point(e.x, e.y));
                        break;
                }
            }
        }
        #endregion

        #region m_mapControl右键菜单项
        /// <summary>
        /// 识别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void indentify_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 漫游
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pan_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 放大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zoomIn_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 缩小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zoomOut_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region mapControl鼠标事件
        /// <summary>
        /// mapControl鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_mapControl_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (m_mapControl.Map.LayerCount == 0) return;
            double x = double.Parse(e.mapX.ToString("0.000"));
            double y = double.Parse(e.mapY.ToString("0.000"));

            this.coordinate_textEdit.Text = x.ToString() + ", " + y.ToString();
        }

        /// <summary>
        /// mapControl鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_mapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 2)
            {
                mapControl_contextMenuStrip.Show(m_mapControl, new Point(e.x, e.y));
            }
        }

        #endregion


        /// <summary>
        /// 要素识别
        /// </summary>
        /// <param name="activeView"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void doIdentify(IActiveView activeView, Int32 x, Int32 y)
        {
            IMap map = activeView.FocusMap;
            IdentifyDialog idenfityDialog = new IdentifyDialog();
            idenfityDialog.Map = map;
            
            // clear the dialog on each mouse click
            idenfityDialog.ClearLayers();
            IScreenDisplay screenDisplay = activeView.ScreenDisplay;

            IDisplay display = screenDisplay; // implicit cast
            idenfityDialog.Display = display;

            IIdentifyDialogProps idenfityDialogProps = (IIdentifyDialogProps)idenfityDialog; // explicit cast
            IEnumLayer enumLayer = map.Layers;
            enumLayer.Reset();
            ILayer layer = enumLayer.Next();
            while(layer!=null)
            {
                idenfityDialog.AddLayerIdentifyPoint(layer,x,y);
                layer = enumLayer.Next();
            }
            idenfityDialog.Show();
        }

        /// <summary>
        /// 打开栅格文件.
        /// </summary>
        /// <param name="rasfilename">栅格文件名</param>
        private void openRasterFile(string rasfilename)
        {
            FileInfo finfo = new FileInfo(rasfilename);

            IWorkspaceFactory pWorkspaceFacotry = new RasterWorkspaceFactory();
            IWorkspace pWorkspace = pWorkspaceFacotry.OpenFromFile(finfo.DirectoryName, 0);
            IRasterWorkspace pRasterWorkspace = pWorkspace as IRasterWorkspace;
            IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(finfo.Name);

            // 影像金字塔的判断与创建
            IRasterPyramid pRasterPyamid = pRasterDataset as IRasterPyramid;
            if (pRasterPyamid != null)
            {
                if (!(pRasterPyamid.Present))
                {
                    pRasterPyamid.Create();
                }
            }

            // 多波段图像
            IRasterBandCollection pRasterBands = (IRasterBandCollection)pRasterDataset;
            int pBandCount = pRasterBands.Count;
            IRaster pRaster = null;
            if (pBandCount > 3)
            {
                pRaster = (pRasterDataset as IRasterDataset2).CreateFullRaster();
            }
            else
            {
                pRaster = pRasterDataset.CreateDefaultRaster();
            }

            IRasterLayer pRasterLayer = new RasterLayer();
            pRasterLayer.CreateFromRaster(pRaster);

            pBandCount = pRasterLayer.BandCount;

            ILayer pLayer = pRasterLayer as ILayer;

            m_mapControl.AddLayer(pLayer);
            m_mapControl.Refresh();
        }



    }
}