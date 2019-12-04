using Gtk;

namespace GtkNamespace
{
    public class Startup
    {
        private readonly MainWindow _mainWindow;

        public Startup(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }
        public void Run()
        {
            Application.Init();

            var app = new Application("org.GtkNamespace.GtkNamespace", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            app.AddWindow(_mainWindow);
            _mainWindow.Show();

            Application.Run();
        }
    }
}