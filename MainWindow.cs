using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace Calculator
{
    class MainWindow : Window
    {
        [UI] private Entry entry = null;
        private Resolver resolver = new Resolver();

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs args)
        {
            Application.Quit();
        }

        private void Digit_Clicked(object sender, EventArgs args)
        {
            if (resolver.IsOperated)
            {
                entry.Text = "";
            }

            if (entry.Text == "0")
            {
                entry.Text = "";
            }

            Button button = (Button)sender;
            entry.Text += button.Label;
            resolver.Input(decimal.Parse(entry.Text));
        }

        private void Dot_Clicked(object sender, EventArgs args)
        {
            if (entry.Text.Contains("."))
            {
                return;
            }

            entry.Text += ".";
            resolver.Input(decimal.Parse(entry.Text));
        }

        private void Operator_Clicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            entry.Text = (resolver.Operate(button.Label)).ToString();
        }

        private void Equal_Clicked(object sender, EventArgs args)
        {
            entry.Text = (resolver.Resolve()).ToString();
        }

        private void Clear_Clicked(object sender, EventArgs args)
        {
            entry.Text = "0";
            resolver.Clear();
        }

        private void Reset_Clicked(object sender, EventArgs args)
        {
            entry.Text = "0";
        }
    }
}
