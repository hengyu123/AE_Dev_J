using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;

namespace AE_Dev_J.Form
{
    /// <summary>
    /// 属性表窗口
    /// </summary>
    public partial class AttributeTableForm : DevExpress.XtraEditors.XtraForm
    {
        private IFeatureLayer m_layer = null;
        private AxMapControl m_mapControl = null; // 属性表需要与mapControl做交互

        public AttributeTableForm(IFeatureLayer layer, MainForm mainForm)
        {
            InitializeComponent();

            m_layer = layer;
            m_mapControl= mainForm.getMapControl();
        }

        private void AttributeTableForm_Load(object sender, EventArgs e)
        {
            this.Text = m_layer.Name + " Attribute Table: " +
                m_layer.FeatureClass.FeatureCount(new ESRI.ArcGIS.Geodatabase.QueryFilter()).ToString() + 
                " features";
            // tian
        }


    }
}