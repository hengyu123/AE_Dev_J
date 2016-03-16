using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AE_Dev_J
{
    /// <summary>
    /// 这个类专门用来与IDL算法做交互
    /// </summary>
    class IdlConnector
    {
        private string m_profilename = null; // *.pro文件完整路径
        public string Profilename
        {
            get { return m_profilename; }
            set { m_profilename = value; }
        }

        private string m_runStr = null; // 运行命令字符串
        public string RunStr
        {
            get { return m_runStr; }
            set { m_runStr = value; }
        }

        private COM_IDL_connectLib.COM_IDL_connect idlCon;

        /// <summary>
        /// 构造函数，需要*.pro文件路径做参数
        /// </summary>
        /// <param name="profilename">*.pro文件路径</param>
        public IdlConnector(string profilename)
        {
            if (profilename == null) { return; }
            idlCon = new COM_IDL_connectLib.COM_IDL_connect();
            idlCon.CreateObject(0, 0, 0);
            m_profilename = profilename;
            try { idlCon.ExecuteString(@".compile '" + m_profilename + "'"); }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// 执行IDL算法
        /// </summary>
        public void run()
        {
            if (m_runStr == null) return;
            try { idlCon.ExecuteString(m_runStr); }
            catch (Exception ex) { throw ex; }
        }

        ~IdlConnector()
        {
            idlCon.DestroyObject();
        }
    }
}
