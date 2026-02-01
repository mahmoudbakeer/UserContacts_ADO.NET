using BuisnessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFPresentationLayer
{
    public partial class EditFrom : Form
    {
        enum enMode { UpdateMode = 1 ,AddNewMode = 2 };
        private enMode _Mode {  get; set; }
        private clsContact _Contact;
        private int _ContactID { get; set; }

        public EditFrom(int ContactID)
        {
            InitializeComponent();
            this._ContactID = ContactID;
            if (this._ContactID == -1)
            {
                _Mode = enMode.AddNewMode;
            }
            else
            {
                _Mode = enMode.UpdateMode;

            }

        }
        private  void _FillCountriesInComboBox() 
        {
            DataTable dt = clsCountry.GetAllCountries();
            foreach (DataRow dr in dt.Rows) 
            {
                cbCountries.Items.Add(dr[1].ToString());
            }
        }
        private void _LoadInfo() 
        {
            _FillCountriesInComboBox();
            if (_Mode == enMode.AddNewMode)
            {
                _Contact = new clsContact();
                lbMainForm.Text = "AddNewContact";
                cbCountries.SelectedIndex = 0;
            }
            else
            {
                _Contact = clsContact.Find(_ContactID);
                lbMainForm.Text = "UpdateContact";
                clsCountry country = clsCountry.Find(_Contact.CountryID);
                cbCountries.SelectedItem = country.CountryName.ToString();
                lblFullName.Text = _Contact.FirstName + " " + _Contact.LastName;
                txtFirstName.Text = _Contact.FirstName;
                txtLastName.Text = _Contact.LastName;
                txtPhone.Text = _Contact.Phone;
                dtpDateOfBirth.Value = _Contact.DateOfBirth;
                txtEmail.Text = _Contact.Email;
                txtAddress.Text = _Contact.Address;
                if (_Contact.ImagePath != string.Empty)
                {
                    pbContactPircture.Load(_Contact.ImagePath);
                    
                }
            }
        }

        private void EditFrom_Load(object sender, EventArgs e)
        {
            _LoadInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Contact.FirstName = txtFirstName.Text;
            _Contact.LastName = txtLastName.Text;
            _Contact.Phone = txtPhone.Text;
            _Contact.Address = txtAddress.Text;
            _Contact.Email = txtEmail.Text;
            _Contact.CountryID = clsCountry.Find(cbCountries.SelectedItem.ToString()).CountryID;
            _Contact.DateOfBirth = dtpDateOfBirth.Value;
            _Contact.Code = string.Empty;
            _Contact.PhoneCode = string.Empty;

            if (_Contact.Save())
            {
                MessageBox.Show("Saved", "The Contact has been Added Successfully ...",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Error", "Somthing Went Wrong , Contact didn't get Saved ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnDeletePicture_Click(object sender, EventArgs e)
        {
            _Contact.ImagePath = string.Empty;
            pbContactPircture.ImageLocation = null;
            btnDeletePicture.Enabled = false;
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Pick A picture";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                _Contact.ImagePath = openFileDialog1.FileName;
                pbContactPircture.Load(_Contact.ImagePath);
            }
        }
    }
}
