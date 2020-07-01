using static PangyaFileCore.IffBaseManager;
using PangyaFileCore.Definitions;
using PangyaFileCore;
using System.Windows.Forms;
using System.Linq;
using System;

namespace PangyaFileCoreTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            new IffBaseManager();
        }

        private void SaveCharacter_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && CharacterName.Text != "")
            {
                var typeID = uint.Parse(txtID.Text);
                var Price = uint.Parse(txtBoxPrice.Text);
                var C0 = ushort.Parse(txtBoxPower.Text);
                var Slot1 = byte.Parse(txtBoxPowerSlot.Text);
                var C1 = ushort.Parse(txtControl.Text);
                var Slot2 = byte.Parse(txtBoxControlSlot.Text);
                var C2 = ushort.Parse(txtImpact.Text);
                var Slot3 = byte.Parse(txtBoxImpactSlot.Text);
                var C3 = ushort.Parse(txtSpin.Text);
                var Slot4 = byte.Parse(txtBoxSpinSlot.Text);
                var C4 = ushort.Parse(txtCurve.Text);
                var Slot5 = byte.Parse(txtBoxCurveSlot.Text);

                var SelectChar = IffEntry.Character.FirstOrDefault(c => c.Value.Base.TypeID == typeID).Value;

                SelectChar.C0 = C0;
                SelectChar.Slot1 = Slot1;
                SelectChar.C1 = C1;
                SelectChar.Slot2 = Slot2;
                SelectChar.C2 = C2;
                SelectChar.Slot3 = Slot3;
                SelectChar.C3 = C3;
                SelectChar.Slot4 = Slot4;
                SelectChar.C4 = C4;
                SelectChar.Slot5 = Slot5;
                SelectChar.Base.ItemPrice = Price;
                if (rdPricePang.Checked)
                {
                    SelectChar.Base.PriceType = 32;
                }
                else if (rdPriceCookie.Checked)
                {
                    SelectChar.Base.PriceType = 1;
                }
            }
        }
        private void lstStrings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstStrings.SelectedItems.Count > 0)
            {
                var SelectChar = IffEntry.Character.ElementAt((int)lstStrings.SelectedItems[0].Tag).Value;
                var level = (ItemLevelEnum)SelectChar.Base.MinLevel;

                CharacterName.Text = SelectChar.Base.Name;
                CheckItemActive.Checked = SelectChar.Base.Enabled > 0;
                CharacterName.Text = SelectChar.Base.Name;
                txtID.Text = SelectChar.Base.TypeID.ToString();
                TxtBoxModel.Text = SelectChar.MPet;
                txtIcon.Text = SelectChar.Base.Icon;
                TxtBoxDiscPrice.Text = SelectChar.Base.DiscountPrice.ToString();
                txtBoxUsedPrice.Text = SelectChar.Base.UsedPrice.ToString();
                TxtBoxTexture.Text = SelectChar.Texture1;
                TxtBoxTexture2.Text = SelectChar.Texture2;
                TxtBoxTexture3.Text = SelectChar.Texture3;
                txtTexture4.Text = SelectChar.Texture4;
                TxtBoxModel.Text = SelectChar.MPet;
                cmbLevel.Text = level.ToString();
                txtBoxPowerSlot.Text = SelectChar.C0.ToString();
                txtBoxPower.Text = SelectChar.Slot1.ToString();
                txtControl.Text = SelectChar.C1.ToString();
                txtBoxControlSlot.Text = SelectChar.Slot2.ToString();
                txtImpact.Text = SelectChar.C2.ToString();
                txtBoxImpactSlot.Text = SelectChar.Slot3.ToString();
                txtSpin.Text = SelectChar.C3.ToString();
                txtBoxSpinSlot.Text = SelectChar.Slot4.ToString();
                txtCurve.Text = SelectChar.C4.ToString();
                txtBoxCurveSlot.Text = SelectChar.Slot5.ToString();
                txtBoxPrice.Text = SelectChar.Base.ItemPrice.ToString();
                TxtDesc.Text = IffEntry.Desc.GetItem(SelectChar.Base.TypeID).Description;
                this.rdPricePang.Checked = false;
                this.rdPriceCookie.Checked = false;
                this.rdPriceNull.Checked = false;
                //this.CheckSaleStart.Checked = SelectChar.Base.DateStart.TimeActive();
                //this.CheckSaleEnd.Checked = SelectChar.Base.DateEnd.TimeActive();
                if (this.CheckSaleStart.Checked)
                {
                    DateStart.Value = new DateTime(SelectChar.Base.DateStart.Year, SelectChar.Base.DateStart.Month, SelectChar.Base.DateStart.Day, SelectChar.Base.DateStart.Minute, SelectChar.Base.DateStart.Second, SelectChar.Base.DateStart.MilliSecond);
                }
                if (this.CheckSaleEnd.Checked)
                {
                    DateEnd.Value = new DateTime(SelectChar.Base.DateEnd.Year, SelectChar.Base.DateEnd.Month, SelectChar.Base.DateEnd.Day, SelectChar.Base.DateEnd.Minute, SelectChar.Base.DateEnd.Second, SelectChar.Base.DateEnd.MilliSecond);
                }
                switch ((ShopFlag)SelectChar.Base.PriceType)
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
                switch ((MoneyFlag)SelectChar.Base.MoneyFlag)
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
                switch (SelectChar.Base.TimeFlag)
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
        }

        private void UpdateStringList()
        {
            int index;

            index = 0;
            if (IffEntry.Character != null)
            {
                if (txtFilter.Text == "")
                {

                    this.lstStrings.Items.Clear();
                    foreach (var str in IffEntry.Character.Values)
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
                    foreach (var str in IffEntry.Character.Values)
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

        private void CharacterEditor_Load(object sender, EventArgs e)
        {
            UpdateStringList();
        }

        private void lstStrings_ColumnClick(object sender, ColumnClickEventArgs e)
        {

        }
    }
}
