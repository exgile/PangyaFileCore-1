using static PangyaFileCore.IffBaseManager;
using PangyaFileCore.Definitions;
using PangyaFileCore;
using System.Windows.Forms;
using System.Linq;
using System;

namespace PangyaFileCoreTest
{
    public partial class ItemFileIFF : Form
    {
        public ItemFileIFF()
        {
            InitializeComponent();
        }

        private void SaveItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No Valid");
        }
        private void lstStrings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstStrings.SelectedItems.Count > 0)
            {
                var SelectItem = IffEntry.Items.Values.ElementAt((int)lstStrings.SelectedItems[0].Tag);
                var level = (ItemLevelEnum)SelectItem.Base.MinLevel;
                CheckItemActive.Checked = SelectItem.Base.Enabled > 0;
                CharacterName.Text = SelectItem.Base.Name;
                txtID.Text = SelectItem.Base.TypeID.ToString();
                TxtBoxModel.Text = "";
                txtIcon.Text = SelectItem.Base.Icon;
                TxtBoxDiscPrice.Text = SelectItem.Base.DiscountPrice.ToString();
                txtBoxUsedPrice.Text = SelectItem.Base.UsedPrice.ToString();
                TxtBoxTexture.Text = SelectItem.Texture;
                TxtBoxTexture2.Text = "";
                TxtBoxTexture3.Text = "";
                TxtBoxModel.Text = "";
                cmbLevel.Text = level.ToString();
                txtBoxPowerSlot.Text = "0";
                txtBoxPower.Text = SelectItem.Power.ToString();
                txtControl.Text = SelectItem.Control.ToString();
                txtBoxControlSlot.Text = "0";
                txtImpact.Text = SelectItem.Accuracy.ToString();
                txtBoxImpactSlot.Text = "0";
                txtSpin.Text = SelectItem.Spin.ToString();
                txtBoxSpinSlot.Text = "0";
                txtCurve.Text = SelectItem.Curve.ToString();
                txtBoxCurveSlot.Text = "0";
                txtBoxPrice.Text = SelectItem.Base.ItemPrice.ToString();
                TxtDesc.Text = IffEntry.Desc.GetItem(SelectItem.Base.TypeID).Description;
                this.rdPricePang.Checked = false;
                this.rdPriceCookie.Checked = false;
                this.rdPriceNull.Checked = false;
                //this.CheckSaleStart.Checked = SelectItem.Base.DateStart.TimeActive();
                //this.CheckSaleEnd.Checked = SelectItem.Base.DateEnd.TimeActive();
                if (cmbSearchByChar.Text != "(All Type)")
                {
                    var ItemType = ItemTypeEnum.Active;
                    if (cmbSearchByChar.Text == "Active")
                    {
                        ItemType = ItemTypeEnum.Active;
                    }
                    else if (cmbSearchByChar.Text == "Passive")
                    {
                        ItemType = ItemTypeEnum.Passive;
                    }
                    else if (cmbSearchByChar.Text == "GM")
                    {
                        ItemType = ItemTypeEnum.GM;
                    }
                    cmbTest.Text = ItemType.ToString();
                }
                else
                {
                    cmbTest.Text = ((ItemTypeEnum)SelectItem.Base.TypeItem).ToString();
                }
                if (this.CheckSaleStart.Checked)
                {
                    DateStart.Value = new DateTime(SelectItem.Base.DateStart.Year, SelectItem.Base.DateStart.Month, SelectItem.Base.DateStart.Day, SelectItem.Base.DateStart.Minute, SelectItem.Base.DateStart.Second, SelectItem.Base.DateStart.MilliSecond);
                }
                if (this.CheckSaleEnd.Checked)
                {
                    DateEnd.Value = new DateTime(SelectItem.Base.DateEnd.Year, SelectItem.Base.DateEnd.Month, SelectItem.Base.DateEnd.Day, SelectItem.Base.DateEnd.Minute, SelectItem.Base.DateEnd.Second, SelectItem.Base.DateEnd.MilliSecond);
                }
                switch ((ShopFlag)SelectItem.Base.PriceType)
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
                switch ((MoneyFlag)SelectItem.Base.MoneyFlag)
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
                switch (SelectItem.Base.TimeFlag)
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
                    foreach (var str in IffEntry.Items.Values)
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
                    foreach (var str in IffEntry.Items.Values)
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

        private void ItemEditor_Load(object sender, EventArgs e)
        {
            UpdateStringList();
        }


        private void SearchTypeByString(object sender, EventArgs e)
        {
            ItemTypeEnum ItemType;
            int index;
            index = 0;

            if (IffEntry.Part != null)
            {
                if (cmbSearchByChar.Text != "")
                {
                    ItemType = ItemTypeEnum.All;
                    if (cmbSearchByChar.Text == "(All Type)")
                    {
                        ItemType = ItemTypeEnum.All;
                    }
                    else if (cmbSearchByChar.Text == "Active")
                    {
                        ItemType = ItemTypeEnum.Active;
                    }
                    else if (cmbSearchByChar.Text == "Passive")
                    {
                        ItemType = ItemTypeEnum.Passive;
                    }
                    else if (cmbSearchByChar.Text == "GM")
                    {
                        ItemType = ItemTypeEnum.GM;
                    }
                    this.lstStrings.Items.Clear();
                    if (cmbSearchByChar.Text != "(All Type)")
                    {
                        foreach (var str in IffEntry.Items.Values)
                        {
                            if (ItemType == (ItemTypeEnum)str.Base.TypeItem)
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
                        foreach (var str in IffEntry.Items.Values)
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
