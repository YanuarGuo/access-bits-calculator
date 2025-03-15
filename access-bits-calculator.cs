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
        private readonly List<string[]> checkedDataBlock0;
        private readonly List<string[]> checkedDataBlock1;
        private readonly List<string[]> checkedDataBlock3;
        private readonly List<string[]> checkedSectorTrailer;
        public System.Windows.Forms.TextBox[] accessBitTextBoxes;
        private readonly bool[,] accessBits = new bool[8, 3];

        public AccessBitsCalculator()
        {
            //LATIHAN ARRAY
            //array access condition

            accessBits = new bool[8, 3];

            // Block 0
            accessBits[3, 1] = true; // C10
            accessBits[7, 2] = true; // C20
            accessBits[3, 2] = true; // C30

            accessBits[3, 0] = !accessBits[7, 2]; // -C20
            accessBits[7, 0] = !accessBits[3, 1]; // -C10
            accessBits[7, 1] = !accessBits[3, 2]; // -C30

            // Block 1
            accessBits[2, 1] = true; // C11
            accessBits[2, 2] = true; // C31
            accessBits[6, 2] = true; // C21

            accessBits[6, 0] = !accessBits[2, 1]; // -C11
            accessBits[6, 1] = !accessBits[2, 2]; // -C31
            accessBits[2, 0] = !accessBits[6, 2]; // -C21

            // Block 2
            accessBits[1, 1] = true; // C12
            accessBits[1, 2] = true; // C32
            accessBits[5, 2] = true; // C22

            accessBits[5, 0] = !accessBits[1, 1]; // -C12
            accessBits[5, 1] = !accessBits[1, 2]; // -C32
            accessBits[1, 0] = !accessBits[5, 2]; // -C22

            // Sector Trailer
            accessBits[0, 1] = true; // C13
            accessBits[4, 2] = true; // C33
            accessBits[0, 2] = true; // C23

            accessBits[0, 0] = !accessBits[4, 2]; // -C33
            accessBits[4, 0] = !accessBits[0, 1]; // -C13
            accessBits[4, 1] = !accessBits[0, 2]; // -C23

            InitializeComponent();
            InitializeTabControl();
            checkedDataBlock0 = GetCheckedRows(dgvDataBlock0);
            checkedDataBlock1 = GetCheckedRows(dgvDataBlock1);
            checkedDataBlock3 = GetCheckedRows(dgvDataBlock2);
            checkedSectorTrailer = GetCheckedRows(dgvSectorTrailer);
            accessBitTextBoxes = [tbAB0, tbAB1, tbAB2, tbAB3];
        }

        private void InitializeTabControl()
        {
            accessConditionsBlock0 =
            [
                new DataBlockCondition(
                    "0",
                    "0",
                    "0",
                    "KEY A | B",
                    "KEY A | B",
                    "KEY A | B",
                    "KEY A | B"
                ),
                new DataBlockCondition("0", "1", "0", "KEY A | B", "Never", "Never", "Never"),
                new DataBlockCondition("1", "0", "0", "KEY A | B", "KEY B", "Never", "Never"),
                new DataBlockCondition("1", "1", "0", "KEY A | B", "KEY B", "KEY B", "KEY A | B"),
                new DataBlockCondition("0", "0", "1", "KEY A | B", "Never", "Never", "KEY A | B"),
                new DataBlockCondition("0", "1", "1", "KEY B", "KEY B", "Never", "Never"),
                new DataBlockCondition("1", "0", "1", "KEY B", "Never", "Never", "Never"),
                new DataBlockCondition("1", "1", "1", "Never", "Never", "Never", "Never"),
            ];

            accessConditionsBlock1 =
            [
                new DataBlockCondition(
                    "0",
                    "0",
                    "0",
                    "KEY A | B",
                    "KEY A | B",
                    "KEY A | B",
                    "KEY A | B"
                ),
                new DataBlockCondition("0", "1", "0", "KEY A | B", "Never", "Never", "Never"),
                new DataBlockCondition("1", "0", "0", "KEY A | B", "KEY B", "Never", "Never"),
                new DataBlockCondition("1", "1", "0", "KEY A | B", "KEY B", "KEY B", "KEY A | B"),
                new DataBlockCondition("0", "0", "1", "KEY A | B", "Never", "Never", "KEY A | B"),
                new DataBlockCondition("0", "1", "1", "KEY B", "KEY B", "Never", "Never"),
                new DataBlockCondition("1", "0", "1", "KEY B", "Never", "Never", "Never"),
                new DataBlockCondition("1", "1", "1", "Never", "Never", "Never", "Never"),
            ];

            accessConditionsBlock2 =
            [
                new DataBlockCondition(
                    "0",
                    "0",
                    "0",
                    "KEY A | B",
                    "KEY A | B",
                    "KEY A | B",
                    "KEY A | B"
                ),
                new DataBlockCondition("0", "1", "0", "KEY A | B", "Never", "Never", "Never"),
                new DataBlockCondition("1", "0", "0", "KEY A | B", "KEY B", "Never", "Never"),
                new DataBlockCondition("1", "1", "0", "KEY A | B", "KEY B", "KEY B", "KEY A | B"),
                new DataBlockCondition("0", "0", "1", "KEY A | B", "Never", "Never", "KEY A | B"),
                new DataBlockCondition("0", "1", "1", "KEY B", "KEY B", "Never", "Never"),
                new DataBlockCondition("1", "0", "1", "KEY B", "Never", "Never", "Never"),
                new DataBlockCondition("1", "1", "1", "Never", "Never", "Never", "Never"),
            ];

            accessConditionsST =
            [
                new SectorTrailerCondition(
                    "0",
                    "0",
                    "0",
                    "Never",
                    "KEY A",
                    "KEY A",
                    "Never",
                    "KEY A",
                    "KEY A"
                ),
                new SectorTrailerCondition(
                    "0",
                    "1",
                    "0",
                    "Never",
                    "Never",
                    "KEY A",
                    "Never",
                    "KEY A",
                    "Never"
                ),
                new SectorTrailerCondition(
                    "1",
                    "0",
                    "0",
                    "Never",
                    "KEY B",
                    "KEY A | B",
                    "Never",
                    "Never",
                    "KEY B"
                ),
                new SectorTrailerCondition(
                    "1",
                    "1",
                    "0",
                    "Never",
                    "Never",
                    "KEY A | B",
                    "Never",
                    "Never",
                    "Never"
                ),
                new SectorTrailerCondition(
                    "0",
                    "0",
                    "1",
                    "Never",
                    "KEY A",
                    "KEY A",
                    "KEY A",
                    "KEY A",
                    "KEY A"
                ),
                new SectorTrailerCondition(
                    "0",
                    "1",
                    "1",
                    "Never",
                    "KEY B",
                    "KEY A | B",
                    "KEY B",
                    "Never",
                    "KEY B"
                ),
                new SectorTrailerCondition(
                    "1",
                    "0",
                    "1",
                    "Never",
                    "Never",
                    "KEY A | B",
                    "KEY B",
                    "Never",
                    "Never"
                ),
                new SectorTrailerCondition(
                    "1",
                    "1",
                    "1",
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

        private static (bool, bool, bool) ConvertToAccessBits(string[] rowData)
        {
            if (rowData == null || rowData.Length < 4)
            {
                return (false, false, false);
            }

            string c1 = rowData[0].Trim().ToUpper();
            string c2 = rowData[1].Trim().ToUpper();
            string c3 = rowData[2].Trim().ToUpper();

            if (c1 == "1" && c2 == "1" && c3 == "1")
                return (true, true, true); // 111
            if (c1 == "1" && c2 == "0" && c3 == "1")
                return (true, false, true); // 101
            if (c1 == "0" && c2 == "1" && c3 == "1")
                return (false, true, true); // 011
            if (c1 == "0" && c2 == "0" && c3 == "1")
                return (false, false, true); // 001
            if (c1 == "1" && c2 == "1" && c3 == "0")
                return (true, true, false); // 110
            if (c1 == "1" && c2 == "0" && c3 == "0")
                return (true, false, false); // 100
            if (c1 == "0" && c2 == "1" && c3 == "0")
                return (false, true, false); // 010
            if (c1 == "0" && c2 == "0" && c3 == "0")
                return (false, false, false); // 000
            return (false, false, false); // Default return
        }

        private void UpdateArray()
        {
            List<string[]> checkedDataBlock0 = GetCheckedRows(dgvDataBlock0) ?? [];
            List<string[]> checkedDataBlock1 = GetCheckedRows(dgvDataBlock1) ?? [];
            List<string[]> checkedDataBlock2 = GetCheckedRows(dgvDataBlock2) ?? [];
            List<string[]> checkedSectorTrailer = GetCheckedRows(dgvSectorTrailer) ?? [];

            (bool, bool, bool)[] accessBlock0 = new (bool, bool, bool)[4];
            (bool, bool, bool)[] accessBlock1 = new (bool, bool, bool)[4];
            (bool, bool, bool)[] accessBlock2 = new (bool, bool, bool)[4];
            (bool, bool, bool)[] accessSectorTrailer = new (bool, bool, bool)[4];

            Func<string[], (bool, bool, bool)> converter = ConvertToAccessBits;

            void UpdateAccessBits((bool, bool, bool)[] access, int startIndex)
            {
                accessBits[startIndex, 1] = access[0].Item1;
                accessBits[startIndex + 4, 2] = access[0].Item2;
                accessBits[startIndex, 2] = access[0].Item3;

                accessBits[startIndex, 0] = !accessBits[startIndex + 4, 2];
                accessBits[startIndex + 4, 0] = !accessBits[startIndex, 1];
                accessBits[startIndex + 4, 1] = !accessBits[startIndex, 2];
            }

            for (int i = 0; i < 4; i++)
            {
                string[] rowBlock0 =
                    (checkedDataBlock0.Count > i) ? checkedDataBlock0[i] : new string[3];
                string[] rowBlock1 =
                    (checkedDataBlock1.Count > i) ? checkedDataBlock1[i] : new string[3];
                string[] rowBlock2 =
                    (checkedDataBlock2.Count > i) ? checkedDataBlock2[i] : new string[3];
                string[] rowSectorTrailer =
                    (checkedSectorTrailer.Count > i) ? checkedSectorTrailer[i] : new string[3];

                accessBlock0[i] = converter(rowBlock0);
                accessBlock1[i] = converter(rowBlock1);
                accessBlock2[i] = converter(rowBlock2);
                accessSectorTrailer[i] = converter(rowSectorTrailer);
            }

            UpdateAccessBits(accessBlock0, 3);
            UpdateAccessBits(accessBlock1, 2);
            UpdateAccessBits(accessBlock2, 1);
            UpdateAccessBits(accessSectorTrailer, 0);

            for (int i = 0; i < 4; i++)
            {
                Debug.WriteLine($"Block 0 Access {i}: {accessBlock0[i]}");
                Debug.WriteLine($"Block 1 Access {i}: {accessBlock1[i]}");
                Debug.WriteLine($"Block 2 Access {i}: {accessBlock2[i]}");
                Debug.WriteLine($"Sector Trailer Access {i}: {accessSectorTrailer[i]}");
            }
        }

        private static void UpdateAccessBitTextBoxes(
            bool[,] accessBits,
            System.Windows.Forms.TextBox[] accessBitTextBoxes
        )
        {
            if (accessBitTextBoxes.Length < 4)
                return;

            for (int col = 0; col < 3; col++)
            {
                int value = 0;
                for (int row = 0; row < 8; row++)
                {
                    if (accessBits[row, col])
                    {
                        value |= (1 << (7 - row));
                    }
                }

                accessBitTextBoxes[col].Text = value.ToString("X2");
                accessBitTextBoxes[3].Text = "69";
            }
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
            string c1,
            string c2,
            string c3,
            string read,
            string write,
            string increment,
            string decTransferRestore
        )
        {
            public bool IsSelected { get; set; } = false;
            public string C1 { get; set; } = c1;
            public string C2 { get; set; } = c2;
            public string C3 { get; set; } = c3;
            public string Read { get; set; } = read;
            public string Write { get; set; } = write;
            public string Increment { get; set; } = increment;
            public string DecTransferRestore { get; set; } = decTransferRestore;
        }

        public class SectorTrailerCondition(
            string c1,
            string c2,
            string c3,
            string keyARead,
            string keyAWrite,
            string accessBitRead,
            string accessBitWrite,
            string keyBRead,
            string keyBWrite
        )
        {
            public bool IsSelected { get; set; } = false;
            public string C1 { get; set; } = c1;
            public string C2 { get; set; } = c2;
            public string C3 { get; set; } = c3;
            public string KeyARead { get; set; } = keyARead;
            public string KeyAWrite { get; set; } = keyAWrite;
            public string AccessBitRead { get; set; } = accessBitRead;
            public string AccessBitWrite { get; set; } = accessBitWrite;
            public string KeyBRead { get; set; } = keyBRead;
            public string KeyBWrite { get; set; } = keyBWrite;
        }
    }
}
