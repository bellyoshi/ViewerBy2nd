﻿using ExCSS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewerBy2nd.WinFormsControlLibrary
{
    public partial class PageNumberForm : Form
    {
        public PageNumberForm(Action<int> action, int max)
        {
            SetPageNumberAction = action;
            PageNumberMax = max;
            InitializeComponent();
        }

        public Action<int> SetPageNumberAction { get; internal set; }
        public int PageNumberMax { get; internal set; }

        private void PageNumberForm_Leave(object sender, EventArgs e)
        {
            Close();
        }

        private void ThrowError()
        {
            var errorMessage = $"1～{PageNumberMax}までの数値を入力してください";
            throw new OperationCanceledException(errorMessage);//todo VaridationException
        }
        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                OkAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void OkAction()
        {
            var numberText = PageNumberTextBox.Text;
            if (String.IsNullOrWhiteSpace(numberText))
            {
                ThrowError();
            }
            if (!int.TryParse(numberText, out var number))
            {
                ThrowError();
            }
            if (number == 0 || number > PageNumberMax)
            {
                ThrowError();
            }

            SetPageNumberAction(number);
            Close();
        }

        private void PageNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 数字以外のキーが押された場合、そのキーの入力をキャンセルします
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }



        private void PageNumberForm_Load(object sender, EventArgs e)
        {
            PageCountLabel.Text = $"/{PageNumberMax}";

            this.CancelButton = CancelCommandButton;

        }

        private void CancelCommandButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
