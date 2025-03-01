using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace access_bits_calculator
{
    public partial class AccessBitsCalculator : Form
    {
        private BindingList<DataBlockCondition> accessConditionsBlock0;
        private BindingList<DataBlockCondition> accessConditionsBlock1;
        private BindingList<DataBlockCondition> accessConditionsBlock2;
        private BindingList<SectorTrailerCondition> accessConditionsST;
        private DataGridView dgvSectorTrailer;
        private DataGridView dgvDataBlock2;
        private DataGridView dgvDataBlock1;
        private DataGridView dgvDataBlock0;
        private List<string[]> checkedDataBlock0;
        private List<string[]> checkedDataBlock1;
        private List<string[]> checkedDataBlock3;
        private List<string[]> checkedSectorTrailer;
        public System.Windows.Forms.TextBox[] accessBitTextBoxes;
        private bool[,] accessBits = new bool[8, 3];

        public AccessBitsCalculator()
        {
            //LATIHAN ARRAY
            //array access condition

            accessBits = new bool[8, 3];

            //0
            accessBits[3, 1] = true; // C10
            accessBits[7, 2] = true; // C20
            accessBits[3, 2] = true; // C30

            accessBits[3, 0] = !(accessBits[7, 2]); // -C20
            accessBits[7, 0] = !(accessBits[3, 1]); // -C10
            accessBits[7, 1] = !(accessBits[3, 2]); // -C30

            //1
            accessBits[2, 1] = true; //C11
            accessBits[2, 2] = true; //C31
            accessBits[6, 2] = true; //C21

            accessBits[6, 0] = !(accessBits[2, 1]); // -C11
            accessBits[6, 1] = !(accessBits[0, 2]); // -C31
            accessBits[2, 0] = !(accessBits[6, 2]); // -C21

            //2
            accessBits[1, 1] = true; // C12
            accessBits[1, 2] = true; // C32
            accessBits[6, 2] = true; // C22

            accessBits[6, 0] = !(accessBits[1, 1]); // -C12
            accessBits[6, 1] = !(accessBits[1, 2]); // -C32
            accessBits[1, 0] = !(accessBits[6, 2]); // -C22

            // sector trailer
            accessBits[0, 1] = true; // C13
            accessBits[4, 2] = true; // C33
            accessBits[0, 2] = true; // C20

            accessBits[0, 0] = !(accessBits[4, 2]); // -C23
            accessBits[4, 0] = !(accessBits[0, 2]); // -C13
            accessBits[4, 1] = !(accessBits[0, 2]); // -C33

            InitializeComponent();
            InitializeTabControl();
            checkedDataBlock0 = GetCheckedRows(dgvDataBlock0);
            checkedDataBlock1 = GetCheckedRows(dgvDataBlock1);
            checkedDataBlock3 = GetCheckedRows(dgvDataBlock2);
            checkedSectorTrailer = GetCheckedRows(dgvSectorTrailer);
            accessBitTextBoxes = new System.Windows.Forms.TextBox[] { tbAB0, tbAB1, tbAB2, tbAB3 };
        }

        private void AccessBitsCalculator_Load(object sender, EventArgs e) { }

        private void InitializeTabControl()
        {
            accessConditionsBlock0 =
            [
                new DataBlockCondition("KEY A | B", "KEY A | B", "KEY A | B", "KEY A | B"),
                new DataBlockCondition("KEY A | B", "Never", "Never", "Never"),
                new DataBlockCondition("KEY A | B", "KEY B", "Never", "Never"),
                new DataBlockCondition("KEY A | B", "KEY B", "KEY B", "KEY A | B"),
                new DataBlockCondition("KEY A | B", "Never", "Never", "KEY A | B"),
                new DataBlockCondition("KEY B", "KEY B", "Never", "Never"),
                new DataBlockCondition("KEY B", "Never", "Never", "Never"),
                new DataBlockCondition("Never", "Never", "Never", "Never"),
            ];

            accessConditionsBlock1 =
            [
                new DataBlockCondition("KEY A | B", "KEY A | B", "KEY A | B", "KEY A | B"),
                new DataBlockCondition("KEY A | B", "Never", "Never", "Never"),
                new DataBlockCondition("KEY A | B", "KEY B", "Never", "Never"),
                new DataBlockCondition("KEY A | B", "KEY B", "KEY B", "KEY A | B"),
                new DataBlockCondition("KEY A | B", "Never", "Never", "KEY A | B"),
                new DataBlockCondition("KEY B", "KEY B", "Never", "Never"),
                new DataBlockCondition("KEY B", "Never", "Never", "Never"),
                new DataBlockCondition("Never", "Never", "Never", "Never"),
            ];

            accessConditionsBlock2 =
            [
                new DataBlockCondition("KEY A | B", "KEY A | B", "KEY A | B", "KEY A | B"),
                new DataBlockCondition("KEY A | B", "Never", "Never", "Never"),
                new DataBlockCondition("KEY A | B", "KEY B", "Never", "Never"),
                new DataBlockCondition("KEY A | B", "KEY B", "KEY B", "KEY A | B"),
                new DataBlockCondition("KEY A | B", "Never", "Never", "KEY A | B"),
                new DataBlockCondition("KEY B", "KEY B", "Never", "Never"),
                new DataBlockCondition("KEY B", "Never", "Never", "Never"),
                new DataBlockCondition("Never", "Never", "Never", "Never"),
            ];

            accessConditionsST =
            [
                new SectorTrailerCondition("Never", "KEY A", "KEY A", "Never", "KEY A", "KEY A"),
                new("Never", "Never", "KEY A", "Never", "KEY A", "Never"),
                new("Never", "KEY B", "KEY A | B", "Never", "Never", "KEY B"),
                new SectorTrailerCondition(
                    "Never",
                    "Never",
                    "KEY A | B",
                    "Never",
                    "Never",
                    "Never"
                ),
                new SectorTrailerCondition("Never", "KEY A", "KEY A", "KEY A", "KEY A", "KEY A"),
                new SectorTrailerCondition(
                    "Never",
                    "KEY B",
                    "KEY A | B",
                    "KEY B",
                    "Never",
                    "KEY B"
                ),
                new SectorTrailerCondition(
                    "Never",
                    "Never",
                    "KEY A | B",
                    "KEY B",
                    "Never",
                    "Never"
                ),
                new SectorTrailerCondition(
                    "Never",
                    "Never",
                    "KEY A | B",
                    "Never",
                    "Never",
                    "Never"
                ),
            ];

            dgvDataBlock0 = new DataGridView();
            dgvDataBlock1 = new DataGridView();
            dgvDataBlock2 = new DataGridView();
            dgvSectorTrailer = new DataGridView();

            AddDataGridViewToTab(tpBlock0, accessConditionsBlock0, dgvDataBlock0);
            AddDataGridViewToTab(tpBlock1, accessConditionsBlock1, dgvDataBlock1);
            AddDataGridViewToTab(tpBlock2, accessConditionsBlock2, dgvDataBlock2);
            AddDataGridViewSectorTrailer(tpST, accessConditionsST, dgvSectorTrailer);
        }

        private void bCalcAccBits_Click(object sender, EventArgs e)
        {
            UpdateArray();

            UpdateAccessBitTextBoxes(accessBits, accessBitTextBoxes);
        }

        private static void AddDataGridViewToTab(
            TabPage tab,
            BindingList<DataBlockCondition> conditions,
            DataGridView dgvDataBlock
        )
        {
            dgvDataBlock.Dock = DockStyle.Fill;
            dgvDataBlock.DataSource = new BindingList<DataBlockCondition>(conditions);
            dgvDataBlock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDataBlock.AllowUserToAddRows = false;
            dgvDataBlock.ReadOnly = true;

            if (dgvDataBlock.Columns["IsSelected"] != null)
                dgvDataBlock.Columns["IsSelected"].Visible = true;

            DataGridViewCheckBoxColumn radioColumn = new()
            {
                HeaderText = "",
                DataPropertyName = "IsSelected",
                Width = 30,
                ReadOnly = false,
            };
            dgvDataBlock.Columns.Insert(0, radioColumn);

            dgvDataBlock.CellClick += (sender, e) =>
            {
                if (e.ColumnIndex == 0)
                {
                    foreach (var item in conditions)
                    {
                        item.IsSelected = false;
                    }
                    conditions[e.RowIndex].IsSelected = true;
                    dgvDataBlock.Refresh();
                }
            };

            tab.Controls.Clear();
            tab.Controls.Add(dgvDataBlock);
        }

        private static void AddDataGridViewSectorTrailer(
            TabPage tab,
            BindingList<SectorTrailerCondition> conditions,
            DataGridView dgvSectorTrailer
        )
        {
            dgvSectorTrailer.Dock = DockStyle.Fill;
            dgvSectorTrailer.DataSource = new BindingList<SectorTrailerCondition>(conditions);
            dgvSectorTrailer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvSectorTrailer.AllowUserToAddRows = false;
            dgvSectorTrailer.ReadOnly = true;

            if (dgvSectorTrailer.Columns["IsSelected"] != null)
                dgvSectorTrailer.Columns["IsSelected"].Visible = true;

            DataGridViewCheckBoxColumn radioColumn = new()
            {
                HeaderText = "",
                DataPropertyName = "IsSelected",
                Width = 30,
                ReadOnly = false,
            };
            dgvSectorTrailer.Columns.Insert(0, radioColumn);

            dgvSectorTrailer.CellClick += (sender, e) =>
            {
                if (e.ColumnIndex == 0)
                {
                    foreach (var item in conditions)
                    {
                        item.IsSelected = false;
                    }
                    conditions[e.RowIndex].IsSelected = true;
                    dgvSectorTrailer.Refresh();
                }
            };

            tab.Controls.Clear();
            tab.Controls.Add(dgvSectorTrailer);
        }

        private static (bool, bool, bool) ConvertToAccessBitsDataBlock(string[] rowData)
        {
            if (rowData == null || rowData.Length < 4)
            {
                return (false, false, false);
            }

            string c1 = rowData[0].Trim().ToUpper();
            string c2 = rowData[1].Trim().ToUpper();
            string c3 = rowData[2].Trim().ToUpper();
            string c4 = rowData[3].Trim().ToUpper();

            if (c1 == "NEVER" && c2 == "NEVER" && c3 == "NEVER" && c4 == "NEVER")
                return (true, true, true); // 111
            if (c1 == "KEY B" && c2 == "NEVER" && c3 == "NEVER" && c4 == "NEVER")
                return (true, false, true); // 101
            if (c1 == "KEY B" && c2 == "KEY B" && c3 == "NEVER" && c4 == "NEVER")
                return (false, true, true); // 011
            if (c1 == "KEY A | B" && c2 == "NEVER" && c3 == "NEVER" && c4 == "KEY A | B")
                return (false, false, true); // 001
            if (c1 == "KEY A | B" && c2 == "KEY B" && c3 == "KEY B" && c4 == "KEY A | B")
                return (true, true, false); // 110
            if (c1 == "KEY A | B" && c2 == "KEY B" && c3 == "NEVER" && c4 == "NEVER")
                return (true, false, false); // 100
            if (c1 == "KEY A | B" && c2 == "NEVER" && c3 == "NEVER" && c4 == "NEVER")
                return (false, true, false); // 010
            if (c1 == "KEY A | B" && c2 == "KEY A | B" && c3 == "KEY A | B" && c4 == "KEY A | B")
                return (false, false, false); // 000
            return (false, false, false); // Default return
        }

        private static (bool, bool, bool) ConvertToAccessBitsSectorTrailer(string[] rowData)
        {
            if (rowData == null || rowData.Length < 6)
            {
                return (false, false, true); // 001
            }

            string readA = rowData[0].Trim().ToUpper();
            string writeA = rowData[1].Trim().ToUpper();
            string readAccessBits = rowData[2].Trim().ToUpper();
            string writeAccessBits = rowData[3].Trim().ToUpper();
            string readB = rowData[4].Trim().ToUpper();
            string writeB = rowData[5].Trim().ToUpper();

            if (
                readA == "NEVER"
                && writeA == "KEY A"
                && readAccessBits == "KEY A"
                && writeAccessBits == "NEVER"
                && readB == "KEY A"
                && writeB == "KEY A"
            )
                return (false, false, false); // 000

            if (
                readA == "NEVER"
                && writeA == "NEVER"
                && readAccessBits == "KEY A"
                && writeAccessBits == "NEVER"
                && readB == "KEY A"
                && writeB == "NEVER"
            )
                return (false, true, false); // 010

            if (
                readA == "NEVER"
                && writeA == "KEY B"
                && readAccessBits == "KEY A | B"
                && writeAccessBits == "NEVER"
                && readB == "NEVER"
                && writeB == "KEY B"
            )
                return (true, false, false); // 100

            if (
                readA == "NEVER"
                && writeA == "NEVER"
                && readAccessBits == "KEY A | B"
                && writeAccessBits == "NEVER"
                && readB == "NEVER"
                && writeB == "NEVER"
            )
                return (true, true, false); // 110

            if (
                readA == "NEVER"
                && writeA == "KEY A"
                && readAccessBits == "KEY A"
                && writeAccessBits == "KEY A"
                && readB == "KEY A"
                && writeB == "KEY A"
            )
                return (false, false, true); // 001

            if (
                readA == "NEVER"
                && writeA == "KEY B"
                && readAccessBits == "KEY A | B"
                && writeAccessBits == "KEY B"
                && readB == "NEVER"
                && writeB == "KEY B"
            )
                return (false, true, true); // 011

            if (
                readA == "NEVER"
                && writeA == "NEVER"
                && readAccessBits == "KEY A | B"
                && writeAccessBits == "KEY B"
                && readB == "NEVER"
                && writeB == "NEVER"
            )
                return (true, false, true); // 101

            if (
                readA == "NEVER"
                && writeA == "NEVER"
                && readAccessBits == "KEY A | B"
                && writeAccessBits == "NEVER"
                && readB == "NEVER"
                && writeB == "NEVER"
            )
                return (true, true, true); // 111

            return (false, false, true); // Default 001
        }

        private void UpdateArray()
        {
            List<string[]> checkedDataBlock0 =
                GetCheckedRows(dgvDataBlock0) ?? new List<string[]>();
            List<string[]> checkedDataBlock1 =
                GetCheckedRows(dgvDataBlock1) ?? new List<string[]>();
            List<string[]> checkedDataBlock2 =
                GetCheckedRows(dgvDataBlock2) ?? new List<string[]>();
            List<string[]> checkedSectorTrailer =
                GetCheckedRows(dgvSectorTrailer) ?? new List<string[]>();

            (bool, bool, bool)[] access = new (bool, bool, bool)[4];

            List<string[]>[] checkedData =
            {
                checkedDataBlock0,
                checkedDataBlock1,
                checkedDataBlock2,
                checkedSectorTrailer,
            };
            Func<string[], (bool, bool, bool)>[] converters =
            {
                ConvertToAccessBitsDataBlock,
                ConvertToAccessBitsDataBlock,
                ConvertToAccessBitsDataBlock,
                ConvertToAccessBitsSectorTrailer,
            };

            for (int i = 0; i < 4; i++)
            {
                access[i] =
                    checkedData[i].Count > 0
                        ? converters[i](checkedData[i][0])
                        : (false, false, false);
            }
        }

        private void UpdateAccessBitTextBoxes(
            bool[,] accessBits,
            System.Windows.Forms.TextBox[] accessBitTextBoxes
        )
        {
            if (accessBitTextBoxes.Length < 4)
                return;

            for (int col = 0; col < 4; col++) // Loop untuk 4 kolom (3 Data Blocks + 1 Sector Trailer)
            {
                int value = 0;
                for (int row = 0; row < 8; row++)
                {
                    if (accessBits[row, col])
                    {
                        value |= (1 << (7 - row));
                    }
                }

                // Konversi ke format heksadesimal dan simpan di TextBox
                accessBitTextBoxes[col].Text = value.ToString("X2");
            }

            // Debugging
            Debug.WriteLine(
                $"Access Bits: {accessBitTextBoxes[0].Text} | {accessBitTextBoxes[1].Text} | {accessBitTextBoxes[2].Text} | {accessBitTextBoxes[3].Text}"
            );
        }

        private static List<string[]> GetCheckedRows(DataGridView dgv)
        {
            List<string[]> checkedRows = [];

            if (dgv == null)
            {
                Trace.WriteLine("DataGridView is null!");
                return checkedRows;
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells.Count == 0 || row.Cells[0].Value == null)
                    continue;

                if (
                    row.Cells[0] is DataGridViewCheckBoxCell checkBoxCell
                    && Convert.ToBoolean(checkBoxCell.Value) == true
                )
                {
                    string[] rowData = new string[row.Cells.Count - 1];

                    for (int i = 1; i < row.Cells.Count; i++)
                    {
                        rowData[i - 1] = row.Cells[i].Value?.ToString() ?? "";
                    }

                    checkedRows.Add(rowData);
                }
            }

            Trace.WriteLine($"Checked Rows Count: {checkedRows.Count}");
            return checkedRows;
        }

        public class DataBlockCondition(
            string read,
            string write,
            string increment,
            string decTransferRestore
        )
        {
            public bool IsSelected { get; set; } = false;
            public string Read { get; set; } = read;
            public string Write { get; set; } = write;
            public string Increment { get; set; } = increment;
            public string DecTransferRestore { get; set; } = decTransferRestore;
        }

        public class SectorTrailerCondition(
            string keyARead,
            string keyAWrite,
            string accessBitRead,
            string accessBitWrite,
            string keyBRead,
            string keyBWrite
        )
        {
            public bool IsSelected { get; set; } = false;
            public string KeyARead { get; set; } = keyARead;
            public string KeyAWrite { get; set; } = keyAWrite;
            public string AccessBitRead { get; set; } = accessBitRead;
            public string AccessBitWrite { get; set; } = accessBitWrite;
            public string KeyBRead { get; set; } = keyBRead;
            public string KeyBWrite { get; set; } = keyBWrite;
        }
    }
}
