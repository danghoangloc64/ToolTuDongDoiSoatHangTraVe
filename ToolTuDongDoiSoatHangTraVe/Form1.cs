using ExcelDataReader;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolTuDongDoiSoatHangTraVe
{
    public partial class Form1 : Form
    {
        private List<DauVao1Model> m_listDauVao1Models;
        private List<DauVao2Model> m_listDauVao2Models;
        private List<DauVao3Model> m_listDauVao3Models;
        private List<FinalModel> m_listFinalModels;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChon1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDauVao1.Text = openFileDialog.FileName;
                    Properties.Settings.Default.DauVao1 = openFileDialog.FileName;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void btnChon2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDauVao2.Text = openFileDialog.FileName;
                    Properties.Settings.Default.DauVao2 = openFileDialog.FileName;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void btnChon3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDauVao3.Text = openFileDialog.FileName;
                    Properties.Settings.Default.DauVao3 = openFileDialog.FileName;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtDauVao1.Text = Properties.Settings.Default.DauVao1;
            txtDauVao2.Text = Properties.Settings.Default.DauVao2;
            txtDauVao3.Text = Properties.Settings.Default.DauVao3;
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtDauVao1.Text))
            {
                MessageBox.Show(this, "Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDauVao2.Text))
            {
                MessageBox.Show(this, "Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDauVao3.Text))
            {
                MessageBox.Show(this, "Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (File.Exists(txtDauVao1.Text) == false)
            {
                MessageBox.Show(this, $"File {txtDauVao1.Text} không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (File.Exists(txtDauVao2.Text) == false)
            {
                MessageBox.Show(this, $"File {txtDauVao2.Text} không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (File.Exists(txtDauVao3.Text) == false)
            {
                MessageBox.Show(this, $"File {txtDauVao3.Text} không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private List<DauVao1Model> GetDataDauVao1Model()
        {
            List<DauVao1Model> result = new List<DauVao1Model>();

            try
            {
                string pathDauVao1 = txtDauVao1.Text;

                using (FileStream stream = File.Open(pathDauVao1, FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                    {
                        DataSet dataSet = reader.AsDataSet();
                        DataTable dt = dataSet.Tables[0];
                        for (int i = 1; i < dt.Rows.Count; i++)
                        {
                            DauVao1Model dauVao1Model = new DauVao1Model()
                            {
                                MA_BILL = dt.Rows[i][0].ToString(),
                                NGUOI_NHAN = dt.Rows[i][1].ToString(),
                                SDT_NHAN = dt.Rows[i][2].ToString(),
                                DIA_CHI_NHAN = dt.Rows[i][3].ToString(),
                                BAO_HIEM = dt.Rows[i][4].ToString(),
                                TIEN_THU_HO = dt.Rows[i][5].ToString(),
                                SO_KIEN = dt.Rows[i][6].ToString(),
                                TRONG_LUONG = dt.Rows[i][7].ToString(),
                                TEN_HANG_HOA = dt.Rows[i][8].ToString(),
                            };
                            result.Add(dauVao1Model);
                        }
                    }
                }
            }
            catch
            {
                AddLog("Có lỗi xảy ra khi đọc đơn đầu vào 1. Vui lòng không mở file khi chạy tool.");
            }

            return result;
        }

        private void AddLog(string log)
        {
            richTextBoxLog.Invoke(new Action(() =>
            {
                richTextBoxLog.AppendText(log + Environment.NewLine);
            }));
        }

        private async void btnChay_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            richTextBoxLog.Clear();
            //if (CheckInput() == false)
            //{
            //    return;
            //}
            await Task.Run(() =>
            {


                m_listDauVao1Models = GetDataDauVao1Model();
                AddLog($"Đã đọc {m_listDauVao1Models.Count} hàng dữ liệu đơn đầu vào 1");

                m_listDauVao2Models = GetDataDauVao2Model();
                AddLog($"Đã đọc {m_listDauVao2Models.Count} hàng dữ liệu đơn trả về khi đã up thông tin (đầu vào 2)");

                m_listDauVao3Models = GetDataDauVao3Model();
                AddLog($"Đã đọc {m_listDauVao3Models.Count} hàng dữ liệu đơn đối soát trả về hàng tuần (đầu vào 3)");

                m_listFinalModels = new List<FinalModel>();

                foreach (var dauVao1Model in m_listDauVao1Models)
                {
                    DauVao2Model checkData2 = m_listDauVao2Models.FirstOrDefault(x => RemoveSpecialCharacters(x.TENNN).Equals(RemoveSpecialCharacters(dauVao1Model.NGUOI_NHAN), StringComparison.OrdinalIgnoreCase)
                                                                                && RemoveSpecialCharacters(x.DIACHI).Equals(RemoveSpecialCharacters(dauVao1Model.DIA_CHI_NHAN), StringComparison.OrdinalIgnoreCase));
                    if (checkData2 != null)
                    {
                        var checkData3 = m_listDauVao3Models.FirstOrDefault(x => x.MVD.Trim().ToLower() == checkData2.MVD.Trim().ToLower());

                        FinalModel finalModel = new FinalModel()
                        {
                            BAO_HIEM_DAUVAO1 = dauVao1Model.BAO_HIEM,
                            DIA_CHI_NHAN_DAUVAO1 = dauVao1Model.DIA_CHI_NHAN,
                            MA_BILL_DAUVAO1 = dauVao1Model.MA_BILL,
                            NGUOI_NHAN_DAUVAO1 = dauVao1Model.NGUOI_NHAN,
                            SDT_NHAN_DAUVAO1 = dauVao1Model.SDT_NHAN,
                            SO_KIEN_DAUVAO1 = dauVao1Model.SO_KIEN,
                            TEN_HANG_HOA_DAUVAO1 = dauVao1Model.TEN_HANG_HOA,
                            TIEN_THU_HO_DAUVAO1 = dauVao1Model.TIEN_THU_HO,
                            TRONG_LUONG_DAUVAO1 = dauVao1Model.TRONG_LUONG,
                            COD_DAUVAO2 = checkData2.COD,
                            DIACHI_DAUVAO2 = checkData2.DIACHI,
                            KG_DAUVAO2 = checkData2.KG,
                            MVD_DAUVAO2 = checkData2.MVD,
                            SDT_DAUVAO2 = checkData2.SDT,
                            TENNN_DAUVAO2 = checkData2.TENNN,
                        };

                        if (checkData3 != null)
                        {
                            finalModel.DIACHIGIAOHANG_DAUVAO3 = checkData3.DIACHIGIAOHANG;
                            finalModel.MVD_DAUVAO3 = checkData3.MVD;
                            finalModel.NGUOINHANHANG_DAUVAO3 = checkData3.NGUOINHANHANG;
                            finalModel.PHIGIAOHANG_DAUVAO3 = checkData3.PHIGIAOHANG;
                            finalModel.SOCANKHACHHANGNHAP_DAUVAO3 = checkData3.SOCANKHACHHANGNHAP;
                            finalModel.SOCANTINHCUOC_DAUVAO3 = checkData3.SOCANTINHCUOC;
                            finalModel.SODIENTHOAINGUOINHAN_DAUVAO3 = checkData3.SODIENTHOAINGUOINHAN;
                            finalModel.THUHO_DAUVAO3 = checkData3.THUHO;
                            finalModel.TONG_DAUVAO3 = checkData3.TONG;
                            finalModel.TRANGTHAIGIAOHANG_DAUVAO3 = checkData3.TRANGTHAIGIAOHANG;


                            finalModel.COD_COMPARE = (double.Parse(finalModel.TIEN_THU_HO_DAUVAO1) - double.Parse(finalModel.COD_DAUVAO2)).ToString();
                            finalModel.KG_COMPARE = (double.Parse(finalModel.KG_DAUVAO2) - double.Parse(finalModel.TRONG_LUONG_DAUVAO1)).ToString();
                            finalModel.COD2_COMPARE = (double.Parse(finalModel.TIEN_THU_HO_DAUVAO1) - double.Parse(finalModel.THUHO_DAUVAO3)).ToString();

                            if (finalModel.COD_COMPARE != "0" || finalModel.COD2_COMPARE != "0")
                            {
                                AddLog($"MVD {finalModel.MVD_DAUVAO3} có trọng lượng bị lệch.");
                            }
                            if (finalModel.KG_COMPARE != "0")
                            {
                                AddLog($"MVD {finalModel.MVD_DAUVAO3} có tiền COD bị lệch.");
                            }

                        }
                        else
                        {
                            Debug.WriteLine($"Mã {checkData2.MVD} không tồn tại trong file 3");
                        }

                        m_listFinalModels.Add(finalModel);
                    }
                    else
                    {
                        FinalModel finalModel = new FinalModel()
                        {
                            BAO_HIEM_DAUVAO1 = dauVao1Model.BAO_HIEM,
                            DIA_CHI_NHAN_DAUVAO1 = dauVao1Model.DIA_CHI_NHAN,
                            MA_BILL_DAUVAO1 = dauVao1Model.MA_BILL,
                            NGUOI_NHAN_DAUVAO1 = dauVao1Model.NGUOI_NHAN,
                            SDT_NHAN_DAUVAO1 = dauVao1Model.SDT_NHAN,
                            SO_KIEN_DAUVAO1 = dauVao1Model.SO_KIEN,
                            TEN_HANG_HOA_DAUVAO1 = dauVao1Model.TEN_HANG_HOA,
                            TIEN_THU_HO_DAUVAO1 = dauVao1Model.TIEN_THU_HO,
                            TRONG_LUONG_DAUVAO1 = dauVao1Model.TRONG_LUONG,
                        };
                        m_listFinalModels.Add(finalModel);
                    }
                }


                //foreach (var dauVao2Model in m_listDauVao2Models)
                //{
                //    var checkData = m_listDauVao1Models.FirstOrDefault(x => RemoveSpecialCharacters(x.NGUOI_NHAN).Equals(RemoveSpecialCharacters(dauVao2Model.TENNN), StringComparison.OrdinalIgnoreCase)
                //                                                                && RemoveSpecialCharacters(x.SDT_NHAN).Equals(RemoveSpecialCharacters(dauVao2Model.SDT), StringComparison.OrdinalIgnoreCase)
                //                                                                && RemoveSpecialCharacters(x.DIA_CHI_NHAN).Equals(RemoveSpecialCharacters(dauVao2Model.DIACHI), StringComparison.OrdinalIgnoreCase));
                //    if (checkData == null)
                //    {
                //        AddLog($"MVD {dauVao2Model.MVD} không tồn tại trong đầu vào 1.");
                //    }    
                //}

                AddLog("Đang xử lý excel.");

                using (ExcelPackage excelPackage = new ExcelPackage("KetQua.xlsx"))
                {
                    ExcelWorkbook excelWorkBook = excelPackage.Workbook;
                    ExcelWorksheet excelWorksheet = excelWorkBook.Worksheets[0];

                    //foreach (var finalModel in m_listFinalModels)


                    for (int i = 0; i < m_listFinalModels.Count; i++)
                    {


                        excelWorksheet.Cells[i + 2, GetColumnNumber("A")].Value = m_listFinalModels[i].MA_BILL_DAUVAO1;
                        excelWorksheet.Cells[i + 2, GetColumnNumber("B")].Value = m_listFinalModels[i].NGUOI_NHAN_DAUVAO1;
                        excelWorksheet.Cells[i + 2, GetColumnNumber("C")].Value = m_listFinalModels[i].SDT_NHAN_DAUVAO1;
                        excelWorksheet.Cells[i + 2, GetColumnNumber("D")].Value = m_listFinalModels[i].DIA_CHI_NHAN_DAUVAO1;
                        excelWorksheet.Cells[i + 2, GetColumnNumber("E")].Value = m_listFinalModels[i].BAO_HIEM_DAUVAO1;
                        excelWorksheet.Cells[i + 2, GetColumnNumber("F")].Value = m_listFinalModels[i].TIEN_THU_HO_DAUVAO1;
                        excelWorksheet.Cells[i + 2, GetColumnNumber("G")].Value = m_listFinalModels[i].SO_KIEN_DAUVAO1;
                        excelWorksheet.Cells[i + 2, GetColumnNumber("H")].Value = m_listFinalModels[i].TRONG_LUONG_DAUVAO1;
                        excelWorksheet.Cells[i + 2, GetColumnNumber("I")].Value = m_listFinalModels[i].TEN_HANG_HOA_DAUVAO1;

                        if (string.IsNullOrEmpty(m_listFinalModels[i].MVD_DAUVAO2) == false)
                        {
                            excelWorksheet.Cells[i + 2, GetColumnNumber("J")].Value = m_listFinalModels[i].MVD_DAUVAO2;
                            excelWorksheet.Cells[i + 2, GetColumnNumber("K")].Value = m_listFinalModels[i].TENNN_DAUVAO2;
                            excelWorksheet.Cells[i + 2, GetColumnNumber("L")].Value = m_listFinalModels[i].SDT_DAUVAO2;
                            excelWorksheet.Cells[i + 2, GetColumnNumber("M")].Value = m_listFinalModels[i].DIACHI_DAUVAO2;
                            excelWorksheet.Cells[i + 2, GetColumnNumber("N")].Value = m_listFinalModels[i].KG_DAUVAO2;
                            excelWorksheet.Cells[i + 2, GetColumnNumber("O")].Value = m_listFinalModels[i].COD_DAUVAO2;
                        }

                        if (string.IsNullOrEmpty(m_listFinalModels[i].MVD_DAUVAO3) == false)
                        {
                            excelWorksheet.Cells[i + 2, GetColumnNumber("R")].Value = m_listFinalModels[i].MVD_DAUVAO3;
                            excelWorksheet.Cells[i + 2, GetColumnNumber("S")].Value = m_listFinalModels[i].TRANGTHAIGIAOHANG_DAUVAO3;
                            excelWorksheet.Cells[i + 2, GetColumnNumber("T")].Value = m_listFinalModels[i].DIACHIGIAOHANG_DAUVAO3;
                            excelWorksheet.Cells[i + 2, GetColumnNumber("U")].Value = m_listFinalModels[i].NGUOINHANHANG_DAUVAO3;
                            excelWorksheet.Cells[i + 2, GetColumnNumber("V")].Value = m_listFinalModels[i].SODIENTHOAINGUOINHAN_DAUVAO3;
                            excelWorksheet.Cells[i + 2, GetColumnNumber("W")].Value = m_listFinalModels[i].SOCANKHACHHANGNHAP_DAUVAO3;
                            excelWorksheet.Cells[i + 2, GetColumnNumber("X")].Value = m_listFinalModels[i].SOCANTINHCUOC_DAUVAO3;
                            excelWorksheet.Cells[i + 2, GetColumnNumber("Y")].Value = m_listFinalModels[i].THUHO_DAUVAO3;
                            excelWorksheet.Cells[i + 2, GetColumnNumber("Z")].Value = m_listFinalModels[i].PHIGIAOHANG_DAUVAO3;
                            excelWorksheet.Cells[i + 2, GetColumnNumber("AA")].Value = m_listFinalModels[i].TONG_DAUVAO3;
                        }





                        excelWorksheet.Cells[i + 2, GetColumnNumber("P")].Value = m_listFinalModels[i].COD_COMPARE;
                        excelWorksheet.Cells[i + 2, GetColumnNumber("Q")].Value = m_listFinalModels[i].KG_COMPARE;
                        excelWorksheet.Cells[i + 2, GetColumnNumber("AB")].Value = m_listFinalModels[i].COD2_COMPARE;

                    }


                    excelPackage.SaveAs("temp.xlsx");

                }
                File.Delete("KetQua.xlsx");
                File.Copy("temp.xlsx", "KetQua.xlsx");
                File.Delete("temp.xlsx");
                AddLog("Xong");

            });
            this.Enabled = true;
        }

        private string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }


        private List<DauVao3Model> GetDataDauVao3Model()
        {
            List<DauVao3Model> result = new List<DauVao3Model>();

            try
            {
                string pathDauVao3 = txtDauVao3.Text;

                using (FileStream stream = File.Open(pathDauVao3, FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                    {
                        DataSet dataSet = reader.AsDataSet();
                        DataTable dt = dataSet.Tables[0];
                        for (int i = 9; i < dt.Rows.Count; i++)
                        {
                            DauVao3Model dauVao3Model = new DauVao3Model()
                            {
                                MVD = dt.Rows[i][GetColumnNumber("A", true)].ToString(),
                                TRANGTHAIGIAOHANG = dt.Rows[i][GetColumnNumber("C", true)].ToString(),
                                DIACHIGIAOHANG = dt.Rows[i][GetColumnNumber("G", true)].ToString(),
                                NGUOINHANHANG = dt.Rows[i][GetColumnNumber("J", true)].ToString(),
                                SODIENTHOAINGUOINHAN = dt.Rows[i][GetColumnNumber("K", true)].ToString(),
                                SOCANKHACHHANGNHAP = dt.Rows[i][GetColumnNumber("L", true)].ToString(),
                                SOCANTINHCUOC = dt.Rows[i][GetColumnNumber("M", true)].ToString(),
                                THUHO = dt.Rows[i][GetColumnNumber("N", true)].ToString(),
                                PHIGIAOHANG = dt.Rows[i][GetColumnNumber("Q", true)].ToString(),
                                TONG = dt.Rows[i][GetColumnNumber("U", true)].ToString(),
                            };
                            result.Add(dauVao3Model);
                        }
                    }
                }
            }
            catch
            {
                AddLog("Có lỗi xảy ra khi đọc đơn trả về khi đã up thông tin (đầu vào 2). Vui lòng không mở file khi chạy tool.");
            }

            return result;
        }

        private int GetColumnNumber(string name, bool hasZero = false)
        {
            name = name.ToUpper();
            int number = 0;
            int pow = 1;
            for (int i = name.Length - 1; i >= 0; i--)
            {
                number += (name[i] - 'A' + 1) * pow;
                pow *= 26;
            }

            return number - (hasZero ? 1 : 0);
        }



        private List<DauVao2Model> GetDataDauVao2Model()
        {
            List<DauVao2Model> result = new List<DauVao2Model>();

            try
            {
                string pathDauVao2 = txtDauVao2.Text;

                using (FileStream stream = File.Open(pathDauVao2, FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                    {
                        DataSet dataSet = reader.AsDataSet();
                        DataTable dt = dataSet.Tables[0];
                        for (int i = 2; i < dt.Rows.Count; i++)
                        {
                            DauVao2Model dauVao2Model = new DauVao2Model()
                            {
                                MVD = dt.Rows[i][GetColumnNumber("B", true)].ToString(),
                                TENNN = dt.Rows[i][GetColumnNumber("G", true)].ToString(),
                                SDT = dt.Rows[i][GetColumnNumber("H", true)].ToString(),
                                DIACHI = dt.Rows[i][GetColumnNumber("I", true)].ToString(),
                                KG = dt.Rows[i][GetColumnNumber("J", true)].ToString(),
                                COD = dt.Rows[i][GetColumnNumber("K", true)].ToString(),
                            };
                            result.Add(dauVao2Model);
                        }
                    }
                }
            }
            catch
            {
                AddLog("Có lỗi xảy ra khi đọc đơn trả về khi đã up thông tin (đầu vào 2). Vui lòng không mở file khi chạy tool.");
            }

            return result;
        }
    }
}
