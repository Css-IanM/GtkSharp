using System;
using Gtk;
using Microsoft.Extensions.Logging;
using UI = Gtk.Builder.ObjectAttribute;

namespace GtkNamespace
{
    public class MainWindow : Window
    {
        [UI] private Label _label1 = null;
        [UI] private Button _button1 = null;

        private int _counter;
        private readonly ILogger<MainWindow> _logger;

        public MainWindow(
            ILogger<MainWindow> logger
        ) : this(new Builder("MainWindow.glade"))
        {
            _logger = logger;
        }

        private MainWindow(Builder builder) : base(builder.GetObject("MainWindow").Handle)
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            _button1.Clicked += Button1_Clicked;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void Button1_Clicked(object sender, EventArgs a)
        {
            _counter++;
            _label1.Text = "Hello World! This button has been clicked " + _counter + " time(s).";
            _logger.LogInformation(_label1.Text);
        }
    }
}
