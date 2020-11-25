using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DPPaint.Views
{
    public class GuiWindow : Form, IGuiWindow
    {
        private readonly int defaultWidth = 1250;
        private readonly int defaultHeight = 800;
        private readonly string defaultTitle = "CSPaint";

        //private readonly Insets defaultButtonDimensions = new Insets(5, 8, 5, 8);
        private readonly Dictionary<EventName, Button> eventButtons = new Dictionary<EventName, Button>();

        public GuiWindow(PaintCanvas canvas)
        {
            canvas.Height = defaultHeight;
            canvas.Width = defaultWidth;
            canvas.Name = defaultTitle;
            canvas.Visible = true;
            canvas.Text = defaultTitle;
            canvas.BackColor = System.Drawing.Color.FromArgb(155, 155, 155);

            Controls.Add(canvas);
            //setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            //    //setExtendedState(JFrame.MAXIMIZED_BOTH);
            //    //JPanel window = createWindow();
            //    //window.add(canvas, BorderLayout.CENTER);
            //    //validate();
        }

        public Button GetButton(EventName eventName)
        {
            if (!eventButtons.ContainsKey(eventName))
            {
                throw new ArgumentNullException($"No button exists for action {eventName}");
            }

            return eventButtons[eventName];
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GuiWindow
            // 
            this.ClientSize = new System.Drawing.Size(771, 388);
            this.Name = "GuiWindow";
            this.ResumeLayout(false);

        }

        //private JPanel createWindow()
        //{
        //    JPanel contentPane = createBackgroundPanel();
        //    JPanel buttonPanel = createMenu();
        //    contentPane.add(buttonPanel, BorderLayout.NORTH);
        //    return contentPane;
        //}

        private Panel CreateMenu()
        {
            Panel buttonPanel = CreateButtonPanel();

            foreach (EventName eventName in Enum.GetValues(typeof(EventName)))
            {
                AddButtonToPanel(eventName, buttonPanel);
            }

            return buttonPanel;
        }

        private void AddButtonToPanel(EventName eventName, Panel panel)
        {
            Button newButton = CreateButton(eventName);
            eventButtons.Add(eventName, newButton);
            panel.Controls.Add(newButton);
        }

        private Button CreateButton(EventName eventName)
        {
            Button newButton = new Button() { Text = eventName.ToString() };
            //newButton.setForeground(Color.BLACK);
            //newButton.setBackground(Color.WHITE);
            //newButton.setBorder(createButtonBorder());
            return newButton;
        }

        //private Border createButtonBorder()
        //{
        //    Border line = new LineBorder(Color.BLACK);
        //    Border margin = new EmptyBorder(defaultButtonDimensions);
        //    return new CompoundBorder(line, margin);
        //}

        private Panel CreateButtonPanel()
        {
            Panel panel = new Panel();
            //FlowLayout flowLayout = (FlowLayout)panel.getLayout();
            //flowLayout.setAlignment(FlowLayout.LEFT);
            //panel.setBackground(Color.lightGray);
            return panel;
        }

        //private JPanel createBackgroundPanel()
        //{
        //    JPanel contentPane = new JPanel();
        //    contentPane.setBorder(new EmptyBorder(0, 0, 0, 0));
        //    contentPane.setLayout(new BorderLayout(0, 0));
        //    contentPane.setBackground(Color.WHITE);
        //    setContentPane(contentPane);
        //    return contentPane;
        //}
    }
}
