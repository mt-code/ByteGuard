using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ByteGuard.ByteGuardInterface.Globals;
using ByteGuard.Tasks;

namespace ByteGuard.ByteGuardInterface.UserControls.MyLibrary
{
    public partial class MarketplaceDefault : UserControl
    {
        private delegate void DisplayInformationDelegate(XmlDocument xmlDocument);

        private readonly Dictionary<string, int> _genreDictionary = new Dictionary<string, int>
        {
            { "Business", 1 },
            { "Education", 2 },
            { "Entertainment", 3 },
            { "Utilities", 4 },
            { "Other", 5 }
        };

        public MarketplaceDefault()
        {
            InitializeComponent();
        }

        private void MarketplaceDefault_Load(object sender, EventArgs e)
        {
            cboGenre.SelectedIndex = 0;

            string marketplaceImage = String.Format("MyPrograms/{0}/marketplace.png", Variables.MyProgramsSelected.Programid);

            if (File.Exists(marketplaceImage))
                picMarketplaceImage.ImageLocation = marketplaceImage;

            Thread threadGetInformation = new Thread(GetMarketplaceInformation);
            threadGetInformation.Start(Variables.MyProgramsSelected.Programid);
        }

        private void btnEnableMarketplace_Click(object sender, EventArgs e)
        {
            if (btnEnableMarketplace.Text == "Enable")
            {
                if (MessageBox.Show("Once marketplace enabled, your program will be shown in the store regardless of your settings. Do you wish to continue?",
                    "Marketplace Enable", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    lblMarketplaceStatus.Text = "Enabled";
                    lblMarketplaceStatus.ForeColor = System.Drawing.Color.DarkGreen;
                    btnEnableMarketplace.Text = "Disable";
                }
            }
            else
            {
                lblMarketplaceStatus.Text = "Disabled";
                lblMarketplaceStatus.ForeColor = System.Drawing.Color.DarkGray;
                btnEnableMarketplace.Text = "Enable";
            }

            btnSaveChanges.Enabled = true;
        }

        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            btnChangeImage.Enabled = false;

            Forms.BlankForm f = new Forms.BlankForm(new MyPrograms.ChangeMarketplaceImage(picMarketplaceImage), true)
            {
                Text = "ByteGuard - Change Marketplace Image"
            };
            f.FormClosing += (closedSender, closedE) => btnChangeImage.Enabled = true;
            f.Show();
        }

        private void btnPreviewWebpage_Click(object sender, EventArgs e)
        {
            btnPreviewWebpage.Enabled = false;

            Forms.BlankForm f = new Forms.BlankForm(new Other.WebpagePreview(), true)
            {
                Text = "ByteGuard - Default Webpage Preview"
            };
            f.FormClosing += (closedSender, closedE) => btnPreviewWebpage.Enabled = true;
            f.Show();
        }

        #region GetInformation methods.

        private void GetMarketplaceInformation(object programid)
        {
            NameValueCollection dataValues = new NameValueCollection { { "pid", programid.ToString() } };

            if (Network.SubmitData("getmpinfo", dataValues))
                ProcessResponse();
        }

        private void ProcessResponse()
        {
            // Gets the webResponse from GlobalVariables.StorageBytes and splits it.
            string webResponse = Variables.WebResponse;

            if (webResponse.Split('[', ']')[1] == "SUCCESS")
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(webResponse.Replace("[SUCCESS]", ""));

                DisplayInformation(xmlDocument);
            }
            else
            {
                Variables.Containers.Main.SetStatus(webResponse.Replace("[ERROR]", ""), 1);
            }
        }

        private void DisplayInformation(XmlDocument xmlDocument)
        {
            if (InvokeRequired)
            {
                Invoke(new DisplayInformationDelegate(DisplayInformation), xmlDocument);
            }
            else
            {
                foreach (XmlNode xmlNode in xmlDocument)
                {
                    foreach (XmlNode xmlMarketplaceNode in xmlNode)
                    {
                        foreach (XmlNode xmlInformationNode in xmlMarketplaceNode)
                        {
                            string innerText = xmlInformationNode.InnerText;

                            switch (xmlInformationNode.Name)
                            {
                                case "price":
                                    numPerpetualPrice.Value = Convert.ToDecimal(innerText);
                                break;

                                case "saleprice":
                                    if (innerText != "")
                                    {
                                        numPerpetualSalePrice.Value = Convert.ToDecimal(innerText);
                                        cbPerpetualOnSale.Checked = true;
                                    }
                                break;

                                case "onemonth":
                                    if (innerText != "")
                                    {
                                        numOneMonthPrice.Value = Convert.ToDecimal(innerText);
                                        cbOneMonthEnabled.Checked = true;
                                    }
                                break;

                                case "threemonth":
                                    if (innerText != "")
                                    {
                                        numThreeMonthPrice.Value = Convert.ToDecimal(innerText);
                                        cbThreeMonthEnabled.Checked = true;
                                    }
                                break;

                                case "sixmonth":
                                    if (innerText != "")
                                    {
                                        numSixMonthPrice.Value = Convert.ToDecimal(innerText);
                                        cbSixMonthEnabled.Checked = true;
                                    }
                                break;

                                case "onemonthsale":
                                    if (innerText != "")
                                    {
                                        numOneMonthSalePrice.Value = Convert.ToDecimal(innerText);
                                        cbOneMonthOnSale.Checked = true;
                                    }
                                break;

                                case "threemonthsale":
                                    if (innerText != "")
                                    {
                                        numThreeMonthSalePrice.Value = Convert.ToDecimal(innerText);
                                        cbThreeMonthOnSale.Checked = true;
                                    }
                                break;

                                case "sixmonthsale":
                                    if (innerText != "")
                                    {
                                        numSixMonthSalePrice.Value = Convert.ToDecimal(innerText);
                                        cbSixMonthOnSale.Checked = true;
                                    }
                                break;

                                case "headline":
                                    txtHeadline.Text = innerText;
                                break;

                                case "subhead":
                                    txtSubHeading.Text = innerText;
                                break;

                                case "genre":
                                    cboGenre.SelectedIndex = _genreDictionary[innerText];
                                break;

                                case "mpenabled":
                                    if (innerText == "1")
                                    {
                                        // Enabled.
                                        lblMarketplaceStatus.Text = "Enabled";
                                        lblMarketplaceStatus.ForeColor = System.Drawing.Color.DarkGreen;
                                        btnEnableMarketplace.Text = "Disable";
                                    }
                                break;
                            }
                        }
                    }
                }

                btnSaveChanges.Enabled = false;
            }
        }

        #endregion

        #region SetInformation methods.

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            Enabled = false;

            if (cboGenre.SelectedIndex == 0)
            {
                Variables.Containers.Main.SetStatus("Please select a software category.", 1);
                Enabled = true;
                return;
            }

            if (txtHeadline.TextLength <= 0 || txtSubHeading.TextLength <= 0)
            {
                Variables.Containers.Main.SetStatus("Please enter a product headline and sub-heading.", 1);
                Enabled = true;
                return;
            }

            NameValueCollection dataValues = new NameValueCollection
            {
                { "pid", Variables.MyProgramsSelected.Programid },
                { "price", numPerpetualPrice.Value.ToString("0.00") },
                { "saleprice", (cbPerpetualOnSale.Checked ? numPerpetualSalePrice.Value.ToString("0.00") : "x") },
                { "onemonth", (cbOneMonthEnabled.Checked ? numOneMonthPrice.Value.ToString("0.00") : "x") },
                { "onemonthsale", (cbOneMonthOnSale.Checked ? numOneMonthSalePrice.Value.ToString("0.00") : "x") },
                { "threemonth", (cbThreeMonthEnabled.Checked ? numThreeMonthPrice.Value.ToString("0.00") : "x") },
                { "threemonthsale", (cbThreeMonthOnSale.Checked ? numThreeMonthSalePrice.Value.ToString("0.00") : "x") },
                { "sixmonth", (cbSixMonthEnabled.Checked ? numSixMonthPrice.Value.ToString("0.00") : "x") },
                { "sixmonthsale", (cbSixMonthOnSale.Checked ? numSixMonthSalePrice.Value.ToString("0.00") : "x") },
                { "headline", txtHeadline.Text },
                { "subhead", txtSubHeading.Text },
                { "genre", cboGenre.Text },
                { "mpenabled", (lblMarketplaceStatus.Text == "Enabled").ToString() }
            };

            Thread threadSetInformation = new Thread(SetMarketplaceInformation);
            threadSetInformation.Start(dataValues);
        }

        private void SetMarketplaceInformation(object _dataValues)
        {
            NameValueCollection dataValues = (NameValueCollection)_dataValues;

            if (Network.SubmitData("setmpinfo", dataValues))
            {
                // Gets the webResponse from GlobalVariables.StorageBytes and splits it.
                string webResponse = Variables.WebResponse;

                Invoke((MethodInvoker) delegate
                {
                    Enabled = true;

                    if (webResponse.Split('[', ']')[1] == "SUCCESS")
                    {
                        btnSaveChanges.Enabled = false;
                        Variables.Containers.Main.SetStatus(webResponse.Replace("[SUCCESS] ", ""), 4);
                    }
                    else
                    {
                        Variables.Containers.Main.SetStatus(webResponse.Replace("[ERROR] ", ""), 1);
                    }
                });
            }
        }

        #endregion

        private void cbPerpetualOnSale_CheckedChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = true;

            numPerpetualSalePrice.Enabled = cbPerpetualOnSale.Checked;
        }

        private void cbOneMonthEnabled_CheckedChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = true;

            numOneMonthPrice.Enabled = cbOneMonthEnabled.Checked;
            cbOneMonthOnSale.Enabled = cbOneMonthEnabled.Checked;

            if (!cbOneMonthEnabled.Checked)
                cbOneMonthOnSale.Checked = false;
        }

        private void cbOneMonthOnSale_CheckedChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = true; 
            
            numOneMonthSalePrice.Enabled = cbOneMonthOnSale.Checked;
        }

        private void cbThreeMonthEnabled_CheckedChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = true;

            numThreeMonthPrice.Enabled = cbThreeMonthEnabled.Checked;
            cbThreeMonthOnSale.Enabled = cbThreeMonthEnabled.Checked;

            if (!cbThreeMonthEnabled.Checked)
                cbThreeMonthOnSale.Checked = false;
        }

        private void cbThreeMonthOnSale_CheckedChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = true; 
            
            numThreeMonthSalePrice.Enabled = cbThreeMonthOnSale.Checked;
        }

        private void cbSixMonthEnabled_CheckedChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = true;

            numSixMonthPrice.Enabled = cbSixMonthEnabled.Checked;
            cbSixMonthOnSale.Enabled = cbSixMonthEnabled.Checked;

            if (!cbSixMonthEnabled.Checked)
                cbSixMonthOnSale.Checked = false;
        }

        private void cbSixMonthOnSale_CheckedChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = true; 
            
            numSixMonthSalePrice.Enabled = cbSixMonthOnSale.Checked;
        }

        private void txtHeadline_TextChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = true;
        }

        private void txtSubHeading_TextChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = true;
        }

        private void numPerpetualPrice_ValueChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = true;
        }

        private void numOneMonthPrice_ValueChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = true;
        }

        private void numThreeMonthPrice_ValueChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = true;
        }

        private void numSixMonthPrice_ValueChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = true;
        }

        private void numPerpetualSalePrice_ValueChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = true;
        }

        private void numOneMonthSalePrice_ValueChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = true;
        }

        private void numThreeMonthSalePrice_ValueChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = true;
        }

        private void numSixMonthSalePrice_ValueChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = true;
        }

        private void cboGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = true;
        }
    }
}
