using System.Drawing;
using System.Windows.Forms;

namespace EAN13
{
    class ChangeTextColor
    {
        
            public static void ChangeColor(RichTextBox rtx, int Start, byte Length = 1)
            {
                rtx.SelectionAlignment = HorizontalAlignment.Left;
                rtx.SelectionStart = Start;
                rtx.SelectionLength = Length;
                rtx.SelectionColor = Color.Crimson;
            }
       
    }
}
