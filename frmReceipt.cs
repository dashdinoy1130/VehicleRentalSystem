using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleRentalSystem
{
    public partial class frmReceipt : Form
    {
        public frmReceipt()
        {
            InitializeComponent();
        }

        private void pnlPaper_Paint(object sender, PaintEventArgs e)
        {

        }
        public frmReceipt(string itemsList, string totalAmount)
        {
            InitializeComponent();
            lblItems.Text = itemsList; 
            lblTotal.Text = "TOTAL: ₱" + totalAmount;
            lblDate.Text = "DATE: " + DateTime.Now.ToString("MM/dd/yyyy HH:mm tt");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Visible = false;

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintReceiptImage);

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;

            if (ppd.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }

            this.Close();
        }
        private void PrintReceiptImage(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
