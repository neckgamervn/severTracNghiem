using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeverTracNghiem
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        IFirebaseClient client()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "R2olJJpLRPZZmHGvIRcGk8urf7ajdCP9yWcVWOwy",
                BasePath = "https://tracnghiem-c8cd5.firebaseio.com"
            };
            IFirebaseClient client = new FirebaseClient(config);

            return client;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            tb_de_thi.Text= client().Get("dethi").Body;
             tb_so_cau_hoi.Text= client().Get("nq").Body;
             tb_dap_an.Text= client().Get("dapan").Body;
            String s = tb_de_thi.Text.Replace("\"", "");

            web_de_thi.Url = new Uri(tb_de_thi.Text.Replace("\"", ""));
         

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btn_edit_de_thi_Click(object sender, EventArgs e)
        {
            btn_ok_de_thi.Enabled = true;
            tb_de_thi.Enabled = true;
            btn_edit_de_thi.Enabled = false;
        }


        private void btn_ok_de_thi_Click(object sender, EventArgs e)
        {
            btn_ok_de_thi.Enabled = false;
            tb_de_thi.Enabled = false;
            btn_edit_de_thi.Enabled = true;
            client().Set("dethi",tb_de_thi.Text);
            web_de_thi.Url = new Uri(tb_de_thi.Text.Replace("\"", ""));
        }



        private void btn_edit_so_cau_hoi_Click(object sender, EventArgs e)
        {
            tb_so_cau_hoi.Enabled = true;
            btn_edit_so_cau_hoi.Enabled = false;
            btn_ok_so_cau_hoi.Enabled = true;
        }



        private void btn_ok_so_cau_hoi_Click(object sender, EventArgs e)
        {
            tb_so_cau_hoi.Enabled = false;
            btn_edit_so_cau_hoi.Enabled = true;
            btn_ok_so_cau_hoi.Enabled = false;
            client().Set("nq", Convert.ToInt32(tb_so_cau_hoi.Text));
        }



        private void btn_edit_dap_an_Click(object sender, EventArgs e)
        {
            tb_dap_an.Enabled = true;
            btn_edit_dap_an.Enabled = false;
            btn_ok_dap_an.Enabled = true;
        }

        private void btn_ok_dap_an_Click(object sender, EventArgs e)
        {
            tb_dap_an.Enabled = false;
            btn_edit_dap_an.Enabled = true;
            btn_ok_dap_an.Enabled = false;
            client().Set("dapan", tb_dap_an.Text);

        }
    }
}
