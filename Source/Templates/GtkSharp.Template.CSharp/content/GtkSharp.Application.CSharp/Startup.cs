using Gtk;

namespace GtkNamespace
{
    public class Startup
    {
        public void Run()
        {
            Application.Init();

            var app = new Application("org.GtkNamespace.GtkNamespace", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            var win = new MainWindow();
            app.AddWindow(win);

            win.Show();
            Application.Run();
        }
    }
}