using System;
using System.Linq;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.ObjectModel;
using BotNSHC.AutoNSHC;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using KAutoHelper;
using System.Drawing;
using System.Windows.Media.Imaging;


namespace BotNSHC
{
	public struct Device
	{
		public Device(string id, int server)
		{
			ID = id;
			SERVER = server;
		}

		public string ID { get; set; }
		public int SERVER { get; set; }
	}
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow : System.Windows.Window
	{
		int currentUser = 0;
		int ketThuc;
		public static bool isStop = false;
		readonly int defaultQQ = 9;
		ObservableCollection<User> listAccounts = new ObservableCollection<User>();
		ObservableCollection<string> listFuncs = new ObservableCollection<string>();
		ObservableCollection<string> listFuncsSelected = new ObservableCollection<string>();
		static List<Device> devicesInfo = new List<Device>();

		public MainWindow()
		{
			InitializeComponent();
			
			LoadFuncs();
			BongVVTbx.Text = Properties.Settings.Default.bongVV;

		}
		private void LoadExcel(string path)
		{
			Excel.Application xlApp = new Excel.Application();
			Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(path);
			Excel.Worksheet xlWorkSheet = xlWorkBook.Worksheets[1];
			Excel.Range xlRange = xlWorkSheet.UsedRange;

			int n = 1;
			for (int i = 2; i <= xlRange.Rows.Count; i++)
			{

				if (xlRange.Cells[i, 1].Value2 != null)
				{
					string ChucNangKhac = "";
					string NVBang = "5NV";
					string Moc = "Moc0";
					int server = 0;
					int qq = 4;

					var username = xlRange.Cells[i, 1].Value2.ToString();
					var pwd = xlRange.Cells[i, 2].Value2.ToString();

					if(xlRange.Cells[i, 3].Value2 != null)
					{
						server = int.Parse(xlRange.Cells[i, 3].Value2.ToString());
					}
					if (xlRange.Cells[i, 4].Value2 != null)
					{
						NVBang = xlRange.Cells[i, 4].Value2.ToString();
					}
					if (xlRange.Cells[i, 5].Value2 != null)
					{
						Moc = xlRange.Cells[i, 5].Value2.ToString();
					}
					if (xlRange.Cells[i, 6].Value2 != null)
					{
						ChucNangKhac = xlRange.Cells[i, 6].Value2.ToString();
					}
					if (xlRange.Cells[i, 7].Value2 != null)
					{
						qq = int.Parse(xlRange.Cells[i, 7].Value2.ToString());
					}

					listAccounts.Add(new User()
					{
						Index = n,
						Username = username,
						Password = pwd,
						Server = server,
						NVBang = NVBang,
						Moc = Moc,
						ChucNangKhac = ChucNangKhac,
						QQ = qq,
					});
					n++;
				}

			}

			DataGridUsers.ItemsSource = listAccounts;
			ketThuc = listAccounts.Count - 1;
			GC.Collect();
			GC.WaitForPendingFinalizers();

			Marshal.ReleaseComObject(xlRange);
			Marshal.ReleaseComObject(xlWorkSheet);

			xlWorkBook.Close();
			Marshal.ReleaseComObject(xlWorkBook);

			xlApp.Quit();
			Marshal.ReleaseComObject(xlApp);

			currentUser = 0;
		}
		#region DieuKhien

		private void GetDevicesBtn(object sender, RoutedEventArgs e)
		{
			List<string> listDevices = KAutoHelper.ADBHelper.GetDevices();
			if (listDevices.Count == 0)
			{
				listDevices.Add("Không có thiết bị kết nối.");
			}
			ListViewDevicesConnected.ItemsSource = listDevices;
		}

		private void SetFileBtn(object sender, RoutedEventArgs e)
		{
			Task t = new Task(() =>
			{

				Dispatcher.Invoke(() =>
				{
					Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
					{
						DefaultExt = ".xlsx"
					};

					Nullable<bool> result = dlg.ShowDialog();

					if (result == true)
					{
						string path = dlg.FileName.ToString();
						listAccounts.Clear();

						LoadExcel(path);
					}
				});

			});
			t.Start();
		}

		private void StartNSHCBtn(object sender, RoutedEventArgs e)
		{
			var listDevices = KAutoHelper.ADBHelper.GetDevices();
			foreach (var device in listDevices)
			{
				Task t = new Task(() =>
				{
					String cmd = "adb -s " + device + " shell monkey -p com.star360mobi.hoangcung -c android.intent.category.LAUNCHER 1";
					KAutoHelper.ADBHelper.ExecuteCMD(cmd);
				});
				t.Start();
			}
		}

		private void StopNSHCBtn(object sender, RoutedEventArgs e)
		{
			var listDevices = KAutoHelper.ADBHelper.GetDevices();
			foreach (var device in listDevices)
			{
				Task t = new Task(() =>
				{
					String cmd = "adb -s " + device + " shell am force-stop com.star360mobi.hoangcung";
					KAutoHelper.ADBHelper.ExecuteCMD(cmd);
				});
				t.Start();
			}
		}

		private void BackUserBtn(object sender, RoutedEventArgs e)
		{
			if (currentUser-1 >= 0)
			{
				currentUser--;
				BackUserTbl.Text = listAccounts[currentUser].Index.ToString() + " : " + listAccounts[currentUser].Username.ToString();
			}
			else
			{
				BackUserTbl.Text ="Tài khoản đầu tiên:" + Environment.NewLine + listAccounts[currentUser].Index.ToString()
					+ " : " + listAccounts[currentUser].Username.ToString();
			}
		}

		private void NextUserBtn(object sender, RoutedEventArgs e)
		{
			if (currentUser+1 < listAccounts.Count)
			{
				currentUser++;
				NextUserTbl.Text = listAccounts[currentUser].Index.ToString() + " : " + listAccounts[currentUser].Username.ToString();
			} else
			{
				NextUserTbl.Text = "Tài khoản cuối cùng:" + Environment.NewLine + listAccounts[currentUser].Index.ToString() +
					" : " + listAccounts[currentUser].Username.ToString();
			}
		}

		private void SetEndBtn(object sender, RoutedEventArgs e)
		{
			var value = endNumber.Text;
			if (!string.IsNullOrEmpty(value))
			{
				ketThuc = int.Parse(value) - 1;
			}

		}

		private void SetStartBtn(object sender, RoutedEventArgs e)
		{
			var value = startNumber.Text;
			if (!string.IsNullOrEmpty(value))
			{
				currentUser = int.Parse(value) - 1;
				startNumber.Clear();
			}


		}
		#endregion
		private void LoginBtn(object sender, RoutedEventArgs e)
		{
			var listDevices = KAutoHelper.ADBHelper.GetDevices();
			foreach (var device in listDevices)
			{
				Task t = new Task(() =>
				{
					try
					{
						User user = listAccounts[currentUser];
						System.Threading.Interlocked.Increment(ref currentUser);
						Device d = new Device(device, user.Server);
						if (devicesInfo.Count == 0)
						{
							devicesInfo.Add(d);
						}
						else
						{
							bool isP = false;
							foreach (var data in devicesInfo)
							{
								if (data.ID.Equals(d.ID))
								{
									isP = true;
									d = data;
									break;
								}
							}

							if (!isP)
							{
								devicesInfo.Add(d);
							}
							else
							{
								if (d.SERVER == user.Server)
								{
									user.Server = 0;
								}
								else
								{
									devicesInfo.Remove(d);
									d.SERVER = user.Server;
									devicesInfo.Add(d);
								}
							}
						}
						Helper.Login(device, user);
						SendText("Đăng nhập tài khoản" + user.Index + " : " + user.Username + " thành công.");
					} catch(Exception ex)
					{
						MessageBox.Show(ex.ToString());
					}
					
				});
				t.Start();
				Thread.Sleep(100);
			}
		}
		private void LogoutBtn(object sender, RoutedEventArgs e)
		{
			var listDevices = KAutoHelper.ADBHelper.GetDevices();
			foreach (var device in listDevices)
			{
				Task t = new Task(() =>
				{
					try
					{

						Helper.Logout(device);
						SendText("Đăng xuất tài khoản" + device + " : " + " thành công.");
					}
					catch(Exception ex)
					{
						MessageBox.Show(ex.ToString());
					}

				});
				t.Start();
			}
		}
		private void PauseBtn(object sender, RoutedEventArgs e)
		{
			isStop = true;
		}
		private void ContinueBtn(object sender, RoutedEventArgs e)
		{
			isStop = false;
		}
		private void Clone30Btn(object sender, RoutedEventArgs e)
		{
			var listDevices = KAutoHelper.ADBHelper.GetDevices();
			var listNames = new List<string>
			{
				"Support",
				"SupportVIP",
				"CrazyDog",
				"IAmBabyGirl"
			};
			var random = new Random();
			var nameUser = NameRegAccount.Text;
			foreach (var device in listDevices)
			{
				Task t = new Task(() =>
				{
					if(listAccounts.Count > 0)
					{
						if (string.IsNullOrEmpty(nameUser))
						{
							nameUser = listNames[random.Next(0, listNames.Count - 1)];
						}

						while (currentUser <= ketThuc)
						{
							Task g = new Task(() => {
								var user = listAccounts[currentUser];
								Interlocked.Increment(ref currentUser);
								Device d = new Device(device, user.Server);
								if (devicesInfo.Count == 0)
								{
									devicesInfo.Add(d);
								}
								else
								{
									bool isP = false;
									foreach (var data in devicesInfo)
									{
										if (data.ID.Equals(d.ID))
										{
											isP = true;
											d = data;
											break;
										}
									}

									if (!isP)
									{
										devicesInfo.Add(d);
									}
									else
									{
										if (d.SERVER == user.Server)
										{
											user.Server = 0;
										}
										else
										{
											devicesInfo.Remove(d);
											d.SERVER = user.Server;
											devicesInfo.Add(d);
										}
									}
								}


								SendText("Device :" + device +". Bắt đầu tài khoản : "+user.Username );
								//Level.Login(device, user);
								//Level.DatTen(device, nameUser + user.Index);
								//Level.LV1toLV11(device);
								Helper.Login(device, user);
								Level.LV11toLV15(device);
								Level.LV15toLV20(device);
								Level.LV20toLV24(device);
								Level.LV24toLV27(device);
								Level.LV27toLV30(device);
								Level.NhanVangPB(device);
								Level.ChonCungDong(device);
								List<string> chucNang = new List<string>();
								if (listFuncsSelected.Count > 0)
								{
									foreach (var value in listFuncsSelected)
									{
										chucNang.Add(value);
									}
								}
								StartAuto(device, chucNang, user);
								Helper.Logout(device);
								SendText("Device :" + device + ". Hoàn thành tài khoản : " + user.Username);
							});
							g.Start();
							g.Wait();
						}
					}
					
				});
				t.Start();
				Thread.Sleep(500);
			}

		}
		private void SetBongVVBtn(object sender, RoutedEventArgs e)
		{
			var value = BongVVTbx.Text;
			if (!string.IsNullOrEmpty(value))
			{
				Properties.Settings.Default.bongVV = value;
				Properties.Settings.Default.Save();
			}
		}
		private void MainPageBtn(object sender, RoutedEventArgs e)
		{
			Task m = new Task(() =>
			{
				var devices = KAutoHelper.ADBHelper.GetDevices();
				var tasks = new List<Task>();
				if (devices.Count > 0)
				{
					foreach (var device in devices)
					{
						Task t = new Task(() =>
						{
							Helper.IsMainPage(device);
						});
						t.Start();
						tasks.Add(t);
					}
				}
				Task.WaitAll(tasks.ToArray());
			});
			m.Start();
		}
		private void VoBang(object sender, RoutedEventArgs e)
		{
			Task m = new Task(() =>
			{
				var devices = KAutoHelper.ADBHelper.GetDevices();
				var tasks = new List<Task>();
				if (devices.Count > 0)
				{
					foreach (var device in devices)
					{
						Task t = new Task(() =>
						{
							Bang.VoBang(device);
						});
						t.Start();
						tasks.Add(t);
					}
				}
				Task.WaitAll(tasks.ToArray());
				Dispatcher.Invoke(() =>
				{
					DoNotThingRbt.IsChecked = true;
				});
				SendText("Vô bang hoàn tất.");
			});
			m.Start();
		}
		private void RoiBang(object sender, RoutedEventArgs e)
		{
			Task m = new Task(() =>
			{
				var devices = KAutoHelper.ADBHelper.GetDevices();
				var tasks = new List<Task>();
				if (devices.Count > 0)
				{
					foreach (var device in devices)
					{
						Task t = new Task(() =>
						{
							Bang.RoiBang(device);
						});
						t.Start();
						tasks.Add(t);
					}
				}
				Task.WaitAll(tasks.ToArray());
				Dispatcher.Invoke(() =>
				{
					DoNotThingRbt.IsChecked = true;
				});
				SendText("Rời bang hoàn tất.");
			});
			m.Start();
		}
		private void GopMax(object sender, RoutedEventArgs e)
		{
			Task m = new Task(() =>
			{
				var devices = KAutoHelper.ADBHelper.GetDevices();
				var tasks = new List<Task>();
				if (devices.Count > 0)
				{
					foreach (var device in devices)
					{
						Task t = new Task(() =>
						{
							Bang.GopMax(device);
						});
						t.Start();
						tasks.Add(t);
					}
				}
				Task.WaitAll(tasks.ToArray());
				Dispatcher.Invoke(() =>
				{
					DoNotThingRbt.IsChecked = true;
				});

				SendText("Góp bang hoàn tất.");
			});
			m.Start();
		}
		private void MuaBongVV(object sender, RoutedEventArgs e)
		{
			Task m = new Task(() =>
			{
				var devices = KAutoHelper.ADBHelper.GetDevices();
				var tasks = new List<Task>();
				if (devices.Count > 0)
				{
					foreach (var device in devices)
					{
						Task t = new Task(() =>
						{
							Helper.MuaBongVV(device);
						});
						t.Start();
						tasks.Add(t);
					}
				}
				Task.WaitAll(tasks.ToArray());
				Dispatcher.Invoke(() =>
				{
					DoNotThingRbt.IsChecked = true;
				});

				SendText("Góp bang hoàn tất.");
			});
			m.Start();
		}
		private void TangBongVV(object sender, RoutedEventArgs e)
		{
			Task m = new Task(() =>
			{
				var devices = KAutoHelper.ADBHelper.GetDevices();
				var tasks = new List<Task>();
				if (devices.Count > 0)
				{
					foreach (var device in devices)
					{
						Task t = new Task(() =>
						{
							Helper.TangBongVV(device);
						});
						t.Start();
						tasks.Add(t);
					}
				}
				Task.WaitAll(tasks.ToArray());
				Dispatcher.Invoke(() =>
				{
					DoNotThingRbt.IsChecked = true;
				});

				SendText("Góp bang hoàn tất.");
			});
			m.Start();
		}
		private void AddFuncBtn(object sender, RoutedEventArgs e)
		{
			if (listFuncLtv.SelectedItem != null)
			{
				var funcSelected = listFuncLtv.SelectedItem.ToString();
				listFuncsSelected.Add(funcSelected);
				funcSelectedLtv.ItemsSource = listFuncsSelected;
			}
		}
		private void UpFuncBtn(object sender, RoutedEventArgs e)
		{
			if (funcSelectedLtv.SelectedItem != null)
			{
				string funcSelected = funcSelectedLtv.SelectedItem.ToString();
				int index = listFuncsSelected.IndexOf(funcSelected);
				if (index > 0)
				{
					listFuncsSelected.RemoveAt(index);
					listFuncsSelected.Insert(index - 1, funcSelected);

					funcSelectedLtv.ItemsSource = listFuncsSelected;
				}
			}
		}
		private void DownFuncBtn(object sender, RoutedEventArgs e)
		{
			if (funcSelectedLtv.SelectedItem != null)
			{
				string funcSelected = funcSelectedLtv.SelectedItem.ToString();
				int index = listFuncsSelected.IndexOf(funcSelected);

				listFuncsSelected.RemoveAt(index);
				listFuncsSelected.Insert(index + 1, funcSelected);

				funcSelectedLtv.ItemsSource = listFuncsSelected;
			}
		}
		private void DeleteFuncBtn(object sender, RoutedEventArgs e)
		{
			if (funcSelectedLtv.SelectedItem != null)
			{
				var funcSelected = funcSelectedLtv.SelectedItem.ToString();
				listFuncsSelected.Remove(funcSelected);

				funcSelectedLtv.ItemsSource = listFuncsSelected;
			}
		}

		private void OneShotBtn(object sender, RoutedEventArgs e)
		{
			var listDevices = KAutoHelper.ADBHelper.GetDevices();
			var user1 = new User
			{
				QQ = defaultQQ
			};
			foreach (var device in listDevices)
			{
				Task t = new Task(() =>
				{
					List<string> list = new List<string>();
					foreach (var value in listFuncsSelected)
					{
						list.Add(value);
					}
					StartAuto(device, list, user1);
				});
				t.Start();
			}

		}
		private void SendText(string text)
		{
			Dispatcher.BeginInvoke(new Action(() =>
			{
				var output = "[" + DateTime.Now.ToString("HH:mm") + "]: " + text;
				TextBlockOutput.Text += output + Environment.NewLine;
				Scroller.ScrollToEnd();
			}));
		}
		private void RunBtn(object sender, RoutedEventArgs e)
		{
			var listDevices = KAutoHelper.ADBHelper.GetDevices();
			foreach (var device in listDevices)
			{
				Task t = new Task(() =>
				{
					if (isStop)
						return;
					while (currentUser <= ketThuc)
					{
						if (isStop)
							return;
						Task g = new Task(() =>
						{
							User user = listAccounts.ElementAt(currentUser);
							SendText("Số " + user.Index.ToString() + " : Bắt đầu");
							Interlocked.Increment(ref currentUser);

							Device d = new Device(device, user.Server);
							if (devicesInfo.Count == 0)
							{
								devicesInfo.Add(d);
							}
							else
							{
								bool isP = false;
								foreach (var data in devicesInfo)
								{
									if (data.ID.Equals(d.ID))
									{
										isP = true;
										d = data;
										break;
									}
								}

								if (!isP)
								{
									devicesInfo.Add(d);
								}
								else
								{
									if (d.SERVER == user.Server)
									{
										user.Server = 0;
									}
									else
									{
										devicesInfo.Remove(d);
										d.SERVER = user.Server;
										devicesInfo.Add(d);
									}
								}
							}

							List<string> chucNang = new List<string>();
							if (listFuncsSelected.Count > 0)
							{
								foreach (var value in listFuncsSelected)
								{
									chucNang.Add(value);
								}
							}
							Helper.Login(device, user);
							StartAuto(device, chucNang, user);
							Helper.Logout(device);
							SendText("Số " + user.Index.ToString() + " : Hoàn thành.");
						});
						g.Start();
						Helper.Delay(1);
						g.Wait();

					}
				});
				t.Start();
				Thread.Sleep(500);
			}
		}
		private void StartAllAccounts(object sender, RoutedEventArgs e)
		{
			var listDevices = KAutoHelper.ADBHelper.GetDevices();
			foreach (var device in listDevices)
			{
				Task t = new Task(() =>
				{
					if (isStop)
						return;
					while (currentUser <= ketThuc)
					{
						if (isStop)
							return;
						Task g = new Task(() =>
						{
							User user = listAccounts.ElementAt(currentUser);
							Interlocked.Increment(ref currentUser);

							Device d = new Device(device, user.Server);
							if (devicesInfo.Count == 0)
							{
								devicesInfo.Add(d);
							}
							else
							{
								bool isP = false;
								foreach (var data in devicesInfo)
								{
									if (data.ID.Equals(d.ID))
									{
										isP = true;
										d = data;
										break;
									}
								}

								if (!isP)
								{
									devicesInfo.Add(d);
								}
								else
								{
									if (d.SERVER == user.Server)
									{
										user.Server = 0;
									}
									else
									{
										devicesInfo.Remove(d);
										d.SERVER = user.Server;
										devicesInfo.Add(d);
									}
								}
							}

							SendText("Số " + user.Index.ToString() + " : bắt đầu.");
							List<string> chucNang = new List<string>();
							if (!string.IsNullOrEmpty(user.ChucNangKhac.ToString()))
							{
								var list = user.ChucNangKhac.Split('-');
								foreach (var value in list)
								{
									chucNang.Add(value);
								}
							}
							
							if (!string.IsNullOrEmpty(user.NVBang.ToString()))
							{
								chucNang.Add("PhucLoi");
								chucNang.Add(user.NVBang.ToString());
							}

							if (!string.IsNullOrEmpty(user.NVBang.ToString()))
							{
								chucNang.Add(user.Moc.ToString());
							}
							if (listFuncsSelected.Count > 0)
							{
								foreach (var value in listFuncsSelected)
								{
									chucNang.Add(value);
								}
							}
							Helper.Login(device, user);
							StartAuto(device, chucNang, user);
							Helper.Logout(device);
							SendText("Số " + user.Index.ToString() + " : Hoàn thành.");
						});
						g.Start();
						Helper.Delay(1);
						g.Wait();

					}
				});
				t.Start();
				Thread.Sleep(500);
			}
		}
		private void LoadFuncs()
		{
			listFuncs.Add("BanBe");
			listFuncs.Add("PhoBan");
			listFuncs.Add("PhucLoi");
			listFuncs.Add("PhucLoiT2");
			listFuncs.Add("PhucLoiUpdate");
			listFuncs.Add("PhucLoiNgayLe");
			listFuncs.Add("PhucLoi31");
			listFuncs.Add("NhanThuong");
			listFuncs.Add("NhapCode");
			listFuncs.Add("DoiLenhBai");
			listFuncs.Add("NhanThu");
			listFuncs.Add("QuaDangNhap");
			listFuncs.Add("MuaBongVV");
			listFuncs.Add("TangBongVV");
			listFuncs.Add("TangFullBong");
			listFuncs.Add("TangFullBongLSV");
			listFuncs.Add("UongRuouNgamTrang");
			listFuncs.Add("BaoDanhLCC");
			listFuncs.Add("UocNguyenCauPhuc");
			listFuncs.Add("ThanTai");
			listFuncs.Add("ThapSangAmAp");
			listFuncs.Add("SuKienCustom");
			listFuncs.Add("GopMax");
			listFuncs.Add("LPLSV");
			listFuncs.Add("VoteLPLSV");
			listFuncs.Add("5NV");
			listFuncs.Add("6NV");
			listFuncs.Add("8NV");
			listFuncs.Add("NVCustom");
			listFuncs.Add("ThanQQMax");
			listFuncs.Add("SuDungVatPham");
			listFuncs.Add("DonTui");
			listFuncs.Add("RoiBang");
			listFuncs.Add("VoBang");

			listFuncs = new ObservableCollection<string>(listFuncs.OrderBy(a => a));
			listFuncLtv.ItemsSource = listFuncs;

		}
		private void StartAuto(string device, List<string> list, User user)
		{
			foreach (var func in list)
			{
				switch (func)
				{

					#region PhucLoi
					case "NhanVangPB":
						Level.NhanVangPB(device);
						break;
					case "RungCay10lan":
						PhucLoi.RungCay5(device);
						break;
					case "PhucLoi":
						PhucLoi.DiemDanh(device);

						var lastDay = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
						var info = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
						DateTimeOffset localServerTime = DateTimeOffset.Now;
						DateTimeOffset localTime = TimeZoneInfo.ConvertTime(localServerTime, info);
						if (lastDay == localTime.Day)
						{
							PhucLoi.PhucLoi31(device);
						}
						SendText("Số " + user.Index.ToString() + " : Phúc lợi hoàn tất.");
						break;
					case "PhucLoiT2":
						PhucLoi.PhucLoiT2(device);
						Helper.NhanThu(device);
						SendText("Số " + user.Index.ToString() + " : Phúc lời thứ 2 xong.");
						break;
					case "PhucLoiUpdate":
						PhucLoi.NhanThuongHoatDong(device);
						Helper.SuDungTheThang(device);
						SendText("Số " + user.Index.ToString() + " : Phúc lợi update xong.");
						break;
					case "PhucLoiNgayLe":
						PhucLoi.NhanThuongHoatDong(device);
						break;
					case "Tieu200V":
						PhucLoi.RungCay5(device);
						PhucLoi.Tieu10V(device);
						break;
					case "ThapSangAmAp":
						PhucLoi.ThapSangAmAp(device);
						break;
					case "QuaDangNhap":
						PhucLoi.QuaDangNhap(device);
						break;
					case "UongRuouNgamTrang":
						SuKien.UongRuouNgamTrang(device);
						break;
					case "ThanTai":
						SuKien.ThanTai(device);
						break;
					case "NhanThuong":
						PhucLoi.TichLuyTieuPhi(device);
						PhucLoi.ThoiTrangSieuHot(device);
						break;
					case "UocNguyenCauPhuc":
						SuKien.UocNguyenCauPhuc(device);
						break;
					case "NVTuyetTrangTungBay":
						PhucLoi.XS20(device);
						PhucLoi.ChiemTinh10(device);
						PhucLoi.TuyetTrangTungBay(device);
						break;
					case "BuffTTTB":
						PhucLoi.BuffTTTB(device);
						break;
					case "BuffTTTBFree":
						PhucLoi.BuffTTTBFree(device);
						break;
					case "PhucLoi31":
						PhucLoi.PhucLoi31(device);
						break;
					case "TTTBHopAnh":
						SuKien.TTTBHopAnh(device);
						break;
					case "MuaXoNuoc":
						SuKien.MuaXoNuoc(device);
						break;
					case "MungSinhNhat":
						SuKien.MungSinhNhat(device);
						break;
					case "NhapCode":
						//4zpzyybfxt
						//1cviyyx943
						Helper.NhapCode(device, "1cviyyx943");
						Helper.NhapCode(device, "4zpzyybfxt");
						break;
					case "DoiLenhBai":
						Helper.DoiLenhBai(device);
						break;
					case "NhanThu":
						Helper.NhanThu(device);
						break;
					case "SuKienCustom":
						SuKien.VanDo(device);
						break;
					#endregion

					#region Bang
					case "VoBang":
						Bang.VoBang(device);
						Bang.IsInBang(device);
						SendText("Số " + user.Index.ToString() + " : Vô bang thành công.");
						break;
					case "RoiBang":
						Bang.RoiBang(device);
						break;
					case "BanBe":
						Bang.BanBe(device);
						Bang.DongYKB(device);
						SendText("Số " + user.Index.ToString() + " : Kết bạn xong.");
						break;
					case "PhoBan":
						SuKien.PhoBan(device);
						SendText("Số " + user.Index.ToString() + " : Phó bản xong.");
						break;
					case "GopMax":
						Bang.GopMax(device);
						SendText("Số " + user.Index.ToString() + " : Đóng góp tất cả hoàn tất.");
						break;
					case "5NV":
						Bang.GopBang(device);
						Bang.ViengTham(device);
						Bang.Bong(device);
						Bang.TraNV(device);
						SendText("Số " + user.Index.ToString() + " : 5NV xong.");
						break;
					case "6NV":
						Bang.GopBang(device);
						Bang.ViengTham(device);
						Bang.Bong(device);
						Bang.ThanQQ(device, user.QQ);
						Bang.TraNV(device);
						SendText("Số " + user.Index.ToString() + " : 6NV xong.");
						break;
					case "MuaLenh":
						Bang.MuaLenh(device);
						break;
					case "8NV":
						Bang.GopBang(device);
						Bang.ViengTham(device);
						Bang.Bong(device);
						Bang.TraNV(device);
						Bang.ThanQQ(device, user.QQ);
						Bang.Dtxs(device);
						Bang.TraNV(device);
						SendText("Số " + user.Index.ToString() + " : 8NV xong.");
						break;
					case "Phat5NVBang":
						Bang.Phat5NVBang(device);
						break;
					case "Phat6NVBang":
						Bang.Phat6NVBang(device);
						break;
					case "Phat8NVBang":
						Bang.Phat8NVBang(device);
						break;
					case "ThanQQMax":
						Bang.ThanQQMax(device, user.QQ);
						break;
					case "NVCustom":
						Bang.GopBang(device);
						Bang.Bong(device);
						Bang.TraNV(device);
						Bang.ThanQQMax(device, user.QQ);
						break;
					#endregion

					//Others
					case "ThuyenRong":
						SuKien.ThuyenRong(device);
						break;
					case "BaoDanhLCC":
						Helper.BaoDanhLCC(device);
						break;
					case "MuaBongVV":
						Helper.MuaBongVV(device);
						break;
					case "TangBongVV":
						Helper.TangBongVV(device);
						break;
					case "TangFullBong":
						Helper.TangFullBong(device);
						break;
					case "TangFullBongLSV":
						Helper.TangFullBongLSV(device);
						break;
					case "LPLSV":
						SuKien.LPLSV(device);
						SendText("Số " + user.Index.ToString() + " : Lplsv xong.");
						break;
					case "VoteLPLSV":
						SuKien.VoteLPLSV(device);
						SendText("Số " + user.Index.ToString() + " : Vote lplsv xong.");
						break;
					case "TTTT":
						NangDong.TTTT(device);
						SendText("Số " + user.Index.ToString() + " : Truyền kỳ thời trang xong.");
						break;
					case "Moc1":
						Bang.MuaLenh(device);
						NangDong.QuanTruong(device);
						SendText("Số " + user.Index.ToString() + " : Mốc 1 xong.");
						break;
					case "Moc2":
						Bang.MuaLenh(device);
						NangDong.DauTruong(device);
						NangDong.QuanTruong(device);
						NangDong.CuongHoaThoiTrang(device);
						NangDong.DonDuocTaiNghe(device);
						NangDong.TrieuBai(device);
						NangDong.TraNVNgay(device);
						SendText("Số " + user.Index.ToString() + " : Mốc 2 xong.");
						break;
					case "SuDungVatPham":
						Helper.SuDungVatPham(device);
						SendText("Số " + user.Index.ToString() + " : Sử dụng vật phẩm hoàn tất.");
						break;
					case "DonTui":
						Helper.DonTui(device);
						Helper.DonTui2(device);
						SendText("Số " + user.Index.ToString() + " : Dọn sạch túi xong.");
						break;
					default:
						break;

				}
			}
		}
		private void Delay(int t)
		{
			while (t > 0)
			{
				Thread.Sleep(TimeSpan.FromSeconds(1));
				t--;
				if (isStop)
					break;
			}
		}

		private void TestBtn(object sender, RoutedEventArgs e)
		{
			var listDevices = KAutoHelper.ADBHelper.GetDevices();
			foreach (var device in listDevices)
			{
				Task t = new Task(() =>
				{

					if (Helper.IsPresent(device, Helper.BitmapFile("cungDau")))
					{
						SendText("ok");
					} else
					{
						SendText("Ok");
					}

				});
				t.Start();
				Thread.Sleep(500);
			}

		}
	}

}