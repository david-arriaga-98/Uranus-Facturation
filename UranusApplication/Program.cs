using ProyectoPuntoNet.DataAccess.Contracts;
using ProyectoPuntoNet.DataAccess.Entities;
using ProyectoPuntoNet.Forms;
using ProyectoPuntoNet.Forms.Reportes;
using System;
using System.Windows.Forms;

namespace ProyectoPuntoNet
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login login = new Login(new UserEntity());
            login.Show();
            Application.Run();
        }
    }
}
