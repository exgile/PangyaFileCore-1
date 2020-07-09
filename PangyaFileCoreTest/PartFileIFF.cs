using static PangyaFileCore.IffBaseManager;
using PangyaFileCore.Definitions;
using PangyaFileCore;
using System.Windows.Forms;
using System.Linq;
using System;
namespace PangyaFileCoreTest
{
    public partial class PartFileIFF : Form
    {
        public PartFileIFF()
        {
            InitializeComponent();
        }
        private void SavePart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No Valid");
        }
        private void lstStrings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstStrings.SelectedItems.Count > 0)
            {
                var SelectPart = IffEntry.Part.Values.ElementAt((int)lstStrings.SelectedItems[0].Tag);
                var level = (ItemLevelEnum)SelectPart.Base.MinLevel;
                CheckItemActive.Checked = SelectPart.Base.Enabled > 0;
                PartName.Text = SelectPart.Base.Name;
                txtID.Text = SelectPart.Base.TypeID.ToString();
                TxtBoxModel.Text = SelectPart.MPet;
                txtIcon.Text = SelectPart.Base.Icon;
                TxtBoxDiscPrice.Text = SelectPart.Base.DiscountPrice.ToString();
                txtBoxUsedPrice.Text = SelectPart.Base.UsedPrice.ToString();
                TxtBoxTexture.Text = SelectPart.Texture1;
                TxtBoxTexture2.Text = SelectPart.Texture2;
                TxtBoxTexture3.Text = SelectPart.Texture3;
                TxtBoxModel.Text = SelectPart.Texture4;
                cmbLevel.Text = level.ToString();
                txtBoxPowerSlot.Text = SelectPart.C0.ToString();
                txtBoxPower.Text = SelectPart.Slot1.ToString();
                txtControl.Text = SelectPart.C1.ToString();
                txtBoxControlSlot.Text = SelectPart.Slot2.ToString();
                txtImpact.Text = SelectPart.C2.ToString();
                txtBoxImpactSlot.Text = SelectPart.Slot3.ToString();
                txtSpin.Text = SelectPart.C3.ToString();
                txtBoxSpinSlot.Text = SelectPart.Slot4.ToString();
                txtCurve.Text = SelectPart.C4.ToString();
                txtBoxCurveSlot.Text = SelectPart.Slot5.ToString();
                txtBoxPrice.Text = SelectPart.Base.ItemPrice.ToString();
                TxtDesc.Text = IffEntry.Desc.GetItem(SelectPart.Base.TypeID).Description;
                this.rdPricePang.Checked = false;
                this.rdPriceCookie.Checked = false;
                this.rdPriceNull.Checked = false;
                //this.CheckSaleStart.Checked = SelectPart.Base.DateStart.TimeActive();
                //this.CheckSaleEnd.Checked = SelectPart.Base.DateEnd.TimeActive();
                cmbTest.Text = ((Character)SelectPart.Base.TypeItem).ToString();
                if (this.CheckSaleStart.Checked)
                {
                    this.CheckSpecialItem.Checked = true;
                    DateStart.Value = new DateTime(SelectPart.Base.DateStart.Year, SelectPart.Base.DateStart.Month, SelectPart.Base.DateStart.Day, SelectPart.Base.DateStart.Minute, SelectPart.Base.DateStart.Second, SelectPart.Base.DateStart.MilliSecond);
                }
                if (this.CheckSaleEnd.Checked)
                {
                    this.CheckSpecialItem.Checked = true;
                    DateEnd.Value = new DateTime(SelectPart.Base.DateEnd.Year, SelectPart.Base.DateEnd.Month, SelectPart.Base.DateEnd.Day, SelectPart.Base.DateEnd.Minute, SelectPart.Base.DateEnd.Second, SelectPart.Base.DateEnd.MilliSecond);
                }
                switch ((ShopFlag)SelectPart.Base.PriceType)
                {
                    case ShopFlag.None:
                        {
                            this.checkStock.Checked = true;
                        }
                        break;
                    case ShopFlag.NonGiftable1:
                    case ShopFlag.NonGiftable:
                        {
                            this.CheckNoGiftable.Checked = true;
                        }
                        break;
                    case ShopFlag.Tradeable:
                    case ShopFlag.Giftable:
                        {
                            this.CheckOnGiftable.Checked = true;
                        }
                        break;
                    case ShopFlag.Active:
                        this.checkStock.Checked = true;
                        break;
                    case ShopFlag.Display:
                        {
                            this.CheckDisplay.Checked = true;
                        }
                        break;
                    default:
                        {

                        }
                        break;
                }
                switch ((MoneyFlag)SelectPart.Base.MoneyFlag)
                {
                    case MoneyFlag.Unknown1:
                        break;
                    case MoneyFlag.BannerSpecial:
                        break;
                    case MoneyFlag.BannerHot:
                        break;
                    case MoneyFlag.BannerNew:
                        break;
                    case MoneyFlag.Unknown2:
                        break;
                    case MoneyFlag.DisplayOnly:
                        break;
                    case MoneyFlag.Type:
                        {
                            rdPricePang.Checked = true;
                        }
                        break;
                    case MoneyFlag.Active:
                        {
                            rdPricePang.Checked = true;
                        }
                        break;
                    case MoneyFlag.None:
                        {
                            rdPriceCookie.Checked = true;
                        }
                        break;
                    default:
                        rdPriceNull.Checked = true;
                        break;
                }
                switch (SelectPart.Base.TimeFlag)
                {
                    case 0:
                        break;
                    case 1:
                        {
                            CheckNewItem.Checked = true;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            UpdateStringList();
        }

        private void BtnClearText_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";

            UpdateStringList();
        }

        private void UpdateStringList()
        {
            int index;

            index = 0;
            if (IffEntry.Part != null)
            {
                if (txtFilter.Text == "")
                {

                    this.lstStrings.Items.Clear();
                    foreach (var str in IffEntry.Part.Values)
                    {
                        ListViewItem item = new ListViewItem(str.Base.TypeID.ToString())
                        {
                            Tag = index
                        };

                        item.SubItems.Add(str.Base.Name);

                        this.lstStrings.Items.Add(item);

                        index++;
                    }
                }
                else
                {
                    this.lstStrings.Items.Clear();
                    foreach (var str in IffEntry.Part.Values)
                    {
                        ListViewItem item = new ListViewItem(str.Base.TypeID.ToString())
                        {
                            Tag = index
                        };

                        item.SubItems.Add(str.Base.Name);

                        index++;
                        bool found = str.Base.Name.Contains(txtFilter.Text);

                        if (found)
                            this.lstStrings.Items.Add(item);
                    }
                }
            }
        }

        private void PartEditor_Load(object sender, EventArgs e)
        {
            UpdateStringList();
        }


        private void SearchCharByString(object sender, EventArgs e)
        {
            int index;

            index = 0;
            if (IffEntry.Part != null)
            {
                if (cmbSearchByChar.Text != "")
                {
                    int selectedIndex = this.cmbSearchByChar.SelectedIndex;
                    selectedIndex -= 1;
                    var chartype = (Character)selectedIndex;
                    this.lstStrings.Items.Clear();
                    if (cmbSearchByChar.Text != "(All Chars)")
                    {
                        foreach (var str in IffEntry.Part.Values)
                        {
                            if (chartype == (Character)str.Base.TypeItem)
                            {
                                ListViewItem item = new ListViewItem(str.Base.TypeID.ToString())
                                {
                                    Tag = index
                                };

                                item.SubItems.Add(str.Base.Name);

                                this.lstStrings.Items.Add(item);

                                index++;
                            }
                        }
                    }
                    else
                    {
                        this.lstStrings.Items.Clear();
                        foreach (var str in IffEntry.Part.Values)
                        {
                            ListViewItem item = new ListViewItem(str.Base.TypeID.ToString())
                            {
                                Tag = index
                            };

                            item.SubItems.Add(str.Base.Name);

                            this.lstStrings.Items.Add(item);

                            index++;
                        }
                    }
                }
            }
        }
    }
}
