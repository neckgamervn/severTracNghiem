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
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeverTracNghiem
{
    public partial class Form1 : Form
    {
       IFirebaseClient client()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "R2olJJpLRPZZmHGvIRcGk8urf7ajdCP9yWcVWOwy",
                BasePath = "https://tracnghiem-c8cd5.firebaseio.com/"
            };
            IFirebaseClient client = new FirebaseClient(config);

            return client;
        }
        String s;

        public Form1()
        {
            
            InitializeComponent();
        }

        protected void Form1_Load(object sender, EventArgs e)
        {
   
            s = client().Get("adminpassword").Body;
        }
      

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (tbInputPassword.Text == "") MessageBox.Show("Wrong Password");
            else
            
            
            if (s ==tbInputPassword.Text)
            {
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();
            }

            else MessageBox.Show("Wrong Password");

          

        }
    }
}
