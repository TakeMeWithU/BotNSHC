using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Point = System.Drawing.Point;

namespace BotNSHC.AutoNSHC
{
	
	class Helper
	{
		
		#region Points
		internal static Point exitPtn = new Point(1242, 45);
		#endregion

		internal static int delayTime = 2;
		internal static void BaoDanhLCC(string device)
		{
			Helper.IsMainPage(device);

			Helper.Click(device, 1221, 365);

			if (Helper.FindAndClick(device, Helper.BitmapFile("lcc")))
			{
				Helper.Click(device, 645, 553);
				Helper.Delay(3);
				Helper.Click(device, 567, 612);
				
			}

			Helper.ReturnToMainpage(device, 1);
			Helper.Click(device, 1086, 89);
		}
		internal static void ClickOutPoint(string device)
		{
			Helper.Click(device, (int)Helper.exitPtn.X, (int)Helper.exitPtn.Y);
		}
		internal static void ChonBong(string device, Bitmap bong)
		{
			bool statut = false;
			int i = 0;
			while (!statut)
			{
				if (MainWindow.isStop)
					return;
				var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
				var hoa = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, bong);
				if (hoa != null)
				{
					Helper.Click(device, hoa.Value.X, hoa.Value.Y + 180);
					Helper.Click(device, 796, 588);
					statut = true;
				}
				else
				{
					KAutoHelper.ADBHelper.Swipe(device, 744, 631, 744, 378, 1500);
					Helper.Delay(Helper.delayTime);
					i++;

					if (i == 20)
					{
						if (Helper.IsPresent(device, Helper.BitmapFile("tangHoaMax"))) 
						{
							Helper.ReturnToMainpage(device, 1);
							Helper.Click(device, 839, 620);
							Helper.Delay(1);
							i = 0;
						} else if (Helper.IsPresent(device, Helper.BitmapFile("tangHoa")))
						{
							Helper.FindAndClick(device, Helper.BitmapFile("tangHoa"));
							i = 0;
						} else if (Helper.IsPresent(device, Helper.BitmapFile("tuongTacXanh")))
						{
							Helper.FindAndClick(device, Helper.BitmapFile("tuongTacXanh"));
							Helper.Click(device, 750, 376);
							Helper.Delay(1);
							Helper.Click(device, 839, 620);
							Helper.Delay(1);
							i = 0;
						} else if (Helper.IsPresent(device, Helper.BitmapFile("thongTin")))
						{
							Helper.Click(device, 750, 376);
							Helper.Delay(1);
							Helper.Click(device, 839, 620);
							Helper.Delay(1);
							i = 0;
						} else if (MatKetNoi(device))
						{
							KetNoiLai(device);

							if (Helper.FindAndClick(device, Helper.BitmapFile("bang")))
							{
								Helper.Delay(1);
								Helper.Click(device, 1073, 620);

								if (Helper.FindAndClick(device, Helper.BitmapFile("tuongTacXanh")))
								{
									Helper.Click(device, 750, 376);
									Helper.Delay(1);
									Helper.Click(device, 839, 620);
									Helper.Delay(1);
								}
							}
							i = 0;
						}
					}

					
				}
			}
		}
		internal static void MuaBongVV(string device)
		{
			Helper.IsMainPage(device);

			if (!Helper.IsPresent(device, Helper.BitmapFile("hoatDong")))
			{
				Helper.Click(device, 1231, 540);
			}

			if (Helper.IsPresent(device, Helper.BitmapFile("tranhMua")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("tranhMua"));

				int i = 0;
				while(true)
				{
					if (i == 20)
					{
						break;
					}
					if(IsPresent(device, BitmapFile("Bong//" + Properties.Settings.Default.bongVV)))
					{
						Helper.Delay(2);
						var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
						var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Helper.BitmapFile("Bong//"+ Properties.Settings.Default.bongVV));
						Helper.Click(device, point.Value.X + 140, point.Value.Y + 140);
						Helper.Click(device, 629, 615);
						break;
					} else
					{
						if (MainWindow.isStop)
							return;
						KAutoHelper.ADBHelper.Swipe(device, 634, 672, 634, 464, 900);
						Delay(2);
						i += 1;
					}
				}
				
			}

			Helper.IsMainPage(device);
		}
		internal static void TangBongVV(string device)
		{
			IsMainPage(device);

			if(!IsPresent(device, BitmapFile("hoaTuoi")))
			{
				if (FindAndClick(device, BitmapFile("tuongTac")))
				{
					if (FindAndClick(device, BitmapFile("hoaTuoi")))
					{
						int i = 0;
						while (true)
						{
							if (i == 5)
							{
								break;
							}
							if (MainWindow.isStop)
								return;
							var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
							var hoa = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BitmapFile("Bong//"+ Properties.Settings.Default.bongVV), 0.8);
							if (hoa != null)
							{
								Helper.Click(device, hoa.Value.X, hoa.Value.Y + 180);
								Helper.Click(device, 580, 177);
								KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + device + " shell input keyevent 279");
								Helper.Delay(2);
								KAutoHelper.ADBHelper.LongPress(device, 833, 424, 3000);
								Helper.Click(device, 796, 588);
								Helper.ClickOutPoint(device);
								break;
							}
							else
							{
								KAutoHelper.ADBHelper.Swipe(device, 744, 631, 744, 378, 1500);
								Helper.Delay(Helper.delayTime);
								i += 1;
							}
						}
						
						
					}
				}
			}

			IsMainPage(device);
		}
		internal static void TangFullBong(string device)
		{
			IsMainPage(device);

			if (!IsPresent(device, BitmapFile("hoaTuoi")))
			{
				if (FindAndClick(device, BitmapFile("tuongTac")))
				{
					if (FindAndClick(device, BitmapFile("hoaTuoi")))
					{
						while (true)
						{
							if (Helper.IsPresent(device, BitmapFile("dungXanh")))
							{
								var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
								var points = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, BitmapFile("dungXanh"));
								if (points.Count > 0)
								{
									foreach (var point in points)
									{
										Helper.Click(device, point.X, point.Y);
										Helper.Click(device, 580, 177);
										KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + device + " shell input keyevent 279");
										Helper.Delay(2);
										KAutoHelper.ADBHelper.LongPress(device, 833, 424, 2000);
										Helper.Click(device, 796, 588);

									}
								}

								KAutoHelper.ADBHelper.Swipe(device, 744, 631, 744, 378, 1500);
								Helper.Delay(Helper.delayTime);
							} else
							{
								break;
							}
						}

						ReturnToMainpage(device, 1);
					}
				}
			}

			IsMainPage(device);
		}
		internal static void TangFullBongLSV(string device)
		{
			IsMainPage(device);

			if (!IsPresent(device, BitmapFile("hoaTuoi")))
			{
				if (FindAndClick(device, BitmapFile("tuongTac")))
				{
					if (FindAndClick(device, BitmapFile("hoaTuoi")))
					{
						Helper.Click(device, 567, 57);
						while (true)
						{
							if (Helper.IsPresent(device, BitmapFile("dungXanh")))
							{
								var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
								var points = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, BitmapFile("dungXanh"));
								if (points.Count > 0)
								{
									foreach (var point in points)
									{
										Helper.Click(device, point.X, point.Y);
										Helper.Click(device, 580, 177);
										KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + device + " shell input keyevent 279");
										Helper.Delay(2);
										KAutoHelper.ADBHelper.LongPress(device, 833, 424, 2000);
										Helper.Click(device, 796, 588);

									}
								}

								KAutoHelper.ADBHelper.Swipe(device, 744, 631, 744, 378, 1500);
								Helper.Delay(Helper.delayTime);
							}
							else
							{
								break;
							}
						}

						ReturnToMainpage(device, 1);
					}
				}
			}

			IsMainPage(device);
		}
		internal static void SuDungVatPham(string device)
		{
			IsMainPage(device);

			Click(device, 1135, 620);

			var vatPham = new List<Bitmap>
			{
				BitmapFile("bac"),
				BitmapFile("vang"),
				BitmapFile("bacNho")
			};

			foreach (var obj in vatPham)
			{
				if (FindAndClick(device, obj))
				{
					if (FindAndClick(device, BitmapFile("dungVatPham")))
					{
						Click(device, 820, 459);
						Click(device, 637, 545);
					}
				}
			}
			IsMainPage(device);
		}
		internal static void SuDungTheThang(string device)
		{
			Helper.IsMainPage(device);

			Helper.Click(device, 1143, 623);


			for (int i = 0; i < 13; i += 1)
			{
				var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
				var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Helper.BitmapFile("theThang"), 0.8);
				if (point != null)
				{
					Helper.Click(device, point.Value.X + 20, point.Value.Y - 100);
					Helper.FindAndClick(device, Helper.BitmapFile("dungVatPham"));
					break;
				} else
				{
					Helper.Click(device, 720, 620);
				}
			}

			Helper.Click(device, (int)Helper.exitPtn.X, (int)Helper.exitPtn.Y);

			Helper.IsMainPage(device);
		}
		internal static void NhanThu(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.FindAndClick(device, Helper.BitmapFile("tuongTac")))
			{
				if (Helper.FindAndClick(device, Helper.BitmapFile("thu")))
				{
					Helper.Click(device, 497, 634);
					Helper.Delay(3);
					KAutoHelper.ADBHelper.Tap(device, 1116, 171);
					Helper.Delay(1);
					Helper.Click(device, 1081, 79);
				}
			}

			Helper.IsMainPage(device);
		}
		internal static void DonTui(string device)
		{
			IsMainPage(device);

			Click(device, 1135, 629);
			Click(device, 578, 74);
			Click(device, 831, 623);

			int a = 239;
			int b = 220;

			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, a, b);
			for (int i = 0; i < 4; i++)
			{
				if (MainWindow.isStop)
					return;
				a += 200;
				KAutoHelper.ADBHelper.Tap(device, a, b);
			}

			a = 239;
			b = 420;

			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, a, b);

			for (int i = 0; i < 4; i++)
			{
				if (MainWindow.isStop)
					return;
				a += 200;
				KAutoHelper.ADBHelper.Tap(device, a, b);
			}

			Click(device, 1065, 629);
			Click(device, 650, 615);
			Click(device, 779, 502);

			ReturnToMainpage(device, 1);

			IsMainPage(device);
		}
		internal static void DonTui2(string device)
		{
			IsMainPage(device);

			Click(device, 1135, 629);
			Click(device, 322, 64);
			Click(device, 831, 623);

			int a = 239;
			int b = 220;

			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, a, b);
			for (int i = 0; i < 4; i++)
			{
				if (MainWindow.isStop)
					return;
				a += 200;
				KAutoHelper.ADBHelper.Tap(device, a, b);
			}


			Click(device, 1065, 629);
			Click(device, 650, 615);
			Click(device, 779, 502);

			ReturnToMainpage(device, 1);

			IsMainPage(device);
		}
		internal static void Login(string device, User user)
		{
			if (IsPresent(device, BitmapFile("cungDau")))
			{
				IsMainPage(device);
				Logout(device);
			}

			bool statut = false;
			int i = 0;
			do
			{
				if(i == 10)
				{
					IsMainPage(device);
					Logout(device);
				}
				if (!IsPresent(device, BitmapFile("dongYXanh")))
				{
					Delay(delayTime);
					i++;
				}
				else
				{
					statut = true;
					Click(device, 637, 647);
				}

			} while (statut != true);


			statut = false;
			i = 0;
			do
			{
				if (!IsPresent(device, BitmapFile("zing")))
				{
					Delay(delayTime);
					i += 1;
				}
				else
				{
					statut = true;
				}
				if (i == 10)
				{
					Click(device, 640, 602);
				}
			} while (statut != true);

			Click(device, 642, 362);

			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, 822, 300);
			Delay(1);
			for (int n = 0; n < 25; n++)
			{
				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.Key(device, KAutoHelper.ADBKeyEvent.KEYCODE_DEL);
			}

			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.InputText(device, user.Username.ToString());
			Delay(1);
			

			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, 615, 360);
			Delay(1);
			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.InputText(device, user.Password.ToString());
			Delay(1);

			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, 637, 435, 2);
			Delay(3);

			if (user.Server > 0)
			{

				ChonServer(device, user.Server);

			}

			Click(device, 640, 602);

			statut = false;
			while (!statut)
			{
				if (IsPresent(device, BitmapFile("conv")))
				{
					Delay(3);
					statut = true;
				}
				else
				{
					if (IsPresent(device, BitmapFile("choiNgay")))
					{
						Click(device, 640, 602);
						Delay(2);
					} else if (IsPresent(device, BitmapFile("nu")))
					{
						Click(device, exitPtn.X, exitPtn.Y);

						ChonServer(device, user.Server);

						Click(device, 640, 602);
					} else if (MatKetNoi(device))
					{
						KetNoiLai(device);
					}


				}
			}

			IsMainPage(device);

			if(!IsPresent(device, BitmapFile("phoBan")))
			{
				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.Tap(device, 634, 292, 3);
				Helper.Delay(2);
			}
		}
		internal static void Logout(string device)
		{
			IsMainPage(device);


			Click(device, (int)exitPtn.X, (int)exitPtn.Y);

			Click(device, 804, 212);
		}
		internal static Bitmap ChonCum(int server)
		{
			Bitmap cum = null;

			if (server > 0 && server <= 10)
			{
				cum = BitmapFile("CumServer//cum1-10");
			}
			else if (server > 10 && server <= 20)
			{
				cum = BitmapFile("CumServer//cum10-20");
			}
			else if (server > 20 && server <= 30)
			{
				cum = BitmapFile("CumServer//cum20-30");
			}
			else if (server > 30 && server <= 40)
			{
				cum = BitmapFile("CumServer//cum30-40");
			}
			else if (server > 40 && server <= 50)
			{
				cum = BitmapFile("CumServer//cum40-50");
			}
			else if (server > 50 && server <= 60)
			{
				cum = BitmapFile("CumServer//cum20-30");
			}
			else if (server > 60 && server <= 70)
			{
				cum = BitmapFile("CumServer//cum60-70");
			}
			else if (server > 70 && server <= 80)
			{
				cum = BitmapFile("CumServer//cum70-80");
			}
			else if (server > 80 && server <= 90)
			{
				cum = BitmapFile("CumServer//cum80-90");
			}
			else if (server > 90 && server <= 100)
			{
				cum = BitmapFile("CumServer//cum90-100");
			}
			else if (server > 100 && server <= 110)
			{
				cum = BitmapFile("CumServer//cum100-110");
			}
			else if (server > 110 && server <= 120)
			{
				cum = BitmapFile("CumServer//cum110-120");
			}
			else if (server > 120 && server <= 130)
			{
				cum = BitmapFile("CumServer//cum120-130");
			}
			else if (server > 130 && server <= 140)
			{
				cum = BitmapFile("CumServer//cum130-140");
			}
			else if (server > 140 && server <= 150)
			{
				cum = BitmapFile("CumServer//cum140-150");
			}
			else if (server > 150 && server <= 160)
			{
				cum = BitmapFile("CumServer//cum150-160");
			}
			else if (server > 160 && server <= 170)
			{
				cum = BitmapFile("CumServer//cum160-170");
			}
			else if (server > 170 && server <= 180)
			{
				cum = BitmapFile("CumServer//cum170-180");
			}
			else if (server > 180 && server <= 190)
			{
				cum = BitmapFile("CumServer//cum180-190");
			}
			else if (server > 190 && server <= 200)
			{
				cum = BitmapFile("CumServer//cum190-200");
			}
			else if (server > 200 && server <= 210)
			{
				cum = BitmapFile("CumServer//cum200-210");
			}
			else if (server > 210 && server <= 220)
			{
				cum = BitmapFile("CumServer//cum210-220");
			}
			else if (server > 220 && server <= 230)
			{
				cum = BitmapFile("CumServer//cum220-230");
			}
			else if (server > 230 && server <= 240)
			{
				cum = BitmapFile("CumServer//cum230-240");
			}

			return cum;
		}
		internal static void ChonServer(string device, int server)
		{
			Click(device, 621, 427);

			int i = 0;
			while (true)
			{
				var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
				var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, ChonCum(server), 0.99);
				if (point != null)
				{
					KAutoHelper.ADBHelper.Tap(device, point.Value.X, point.Value.Y);
					Delay(1);
					break;
				} else
				{

					
					if (MainWindow.isStop)
						return;
					KAutoHelper.ADBHelper.Swipe(device, 267, 481, 267, 300);
					Delay(2);
					i += 1;
					if (i >= 10)
					{
						i = 0;

						Click(device, 1105, 80);

						Click(device, 621, 427);
					}
				}
			}

			List<Point> points = new List<Point>
			{
				new Point(892, 588),
				new Point(537, 282),
				new Point(884, 282),
				new Point(537, 357),
				new Point(884, 357),
				new Point(537, 446),
				new Point(884, 446),
				new Point(537, 518),
				new Point(884, 518),
				new Point(537, 594),
			};

			Click(device, points[Math.Abs(server) % 10].X, points[Math.Abs(server) % 10].Y);
		}
		internal static void IsMainPage(string device)
		{
			bool statut = false;
			if (MainWindow.isStop)
				return;
			while (!statut)
			{

				if (MainWindow.isStop)
					return;
				if (IsPresent(device, BitmapFile("cungDau")))
				{
					statut = true;
				}
				else
				{
					if (MainWindow.isStop)
						return;
					if (FindAndClick(device, BitmapFile("exitPtn")))
					{
						Delay(1);
					}
					else
					{
						if (MainWindow.isStop)
							return;
						if (FindAndClick(device, BitmapFile("quayLai")))
						{
							Delay(1);
						}
						else
						{
							if (MainWindow.isStop)
								return;
							if (FindAndClick(device, BitmapFile("roi")))
							{
								Delay(1);
							}
							else
							{
								if (MainWindow.isStop)
									return;
								KAutoHelper.ADBHelper.Tap(device, 1078, 104);
								Delay(2);
							}
						}

					}
				}
			}
		}
		internal static void Click(string device, int a, int b)
		{
			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, a, b);
			Delay(delayTime);
		}
		internal static Bitmap BitmapFile(string fileName)
		{
			return (Bitmap)Bitmap.FromFile("Data//" + fileName + ".png");
		}
		internal static bool IsPresent(string device, Bitmap place)
		{
			bool result = false;

			var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
			var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, place, 0.8);
			if (point != null)
			{
				result = true;
			}

			return result;
		}
		internal static bool FindsAndClicks(string device, Bitmap place)
		{
			bool result = false;

			var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
			var places = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, place, 0.8);
			if (places.Count > 0)
			{
				foreach (var point in places)
				{
					KAutoHelper.ADBHelper.Tap(device, point.X + 10, point.Y + 10);
					Delay(delayTime);
				}
				result = true;
			}

			return result;
		}
		internal static bool FindAndClick(string device, Bitmap place)
		{
			bool result = false;

			var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
			var places = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, place, 0.8);
			if (places != null)
			{
				KAutoHelper.ADBHelper.Tap(device, places.Value.X + 10, places.Value.Y + 10);
				Delay(3);
				result = true;
			}
			return result;
		}
		internal static void Delay(int t)
		{
			while (t > 0)
			{
				Thread.Sleep(TimeSpan.FromSeconds(1));
				t--;
				if (MainWindow.isStop)
					break;
			}
		}
		internal static void ReturnToMainpage(string device, int i)
		{
			for(int n = 0; n < i; n += 1)
			{
				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.Tap(device, (int)exitPtn.X, (int)exitPtn.Y);
				Helper.Delay(2);
			}
		}
		internal static void KetNoiLai(string device)
		{
			String close = "adb -s " + device + " shell am force-stop com.star360mobi.hoangcung";
			KAutoHelper.ADBHelper.ExecuteCMD(close);
			Helper.Delay(3);

			String open = "adb -s " + device + " shell monkey -p com.star360mobi.hoangcung -c android.intent.category.LAUNCHER 1";
			KAutoHelper.ADBHelper.ExecuteCMD(open);
			Helper.Delay(5);

			bool statut = false;
			int i = 0;
			do
			{
				if (i == 10 || IsPresent(device, BitmapFile("cungDau")))
				{
					IsMainPage(device);
					Logout(device);
				}
				if (!IsPresent(device, BitmapFile("dongYXanh")))
				{
					Delay(delayTime);
					i++;
				}
				else
				{
					statut = true;
					Click(device, 637, 647);
				}

			} while (statut != true);

			statut = false;
			while (!statut)
			{
				if (IsPresent(device, BitmapFile("conv")))
				{
					Delay(3);
					statut = true;
				}
				else
				{
					if (IsPresent(device, BitmapFile("choiNgay")))
					{
						Click(device, 640, 602);
						Delay(2);
					}
				}
			}

			IsMainPage(device);
		}
		internal static bool MatKetNoi(string device)
		{
			if(Helper.IsPresent(device, Helper.BitmapFile("dangXuat")) || Helper.IsPresent(device, Helper.BitmapFile("thuLai")))
			{
				return true;
			} else
			{
				return false;
			}
		}

		internal static bool TuiDay(string device)
		{
			if(IsPresent(device, BitmapFile("dongYXanh")) && IsPresent(device, BitmapFile("huy")))
			{
				FindAndClick(device, BitmapFile("dongYXanh"));
				return true;
			} else
			{
				return false;
			}
		}
		internal static void MoRongTui(string device)
		{
			Helper.Click(device, 1073, 624);
			KAutoHelper.ADBHelper.Tap(device, 744, 275, 4);
			Helper.Click(device, 750, 549);
			Helper.Delay(1);
			ReturnToMainpage(device, 1);
		}
		internal static void NhapCode(string device, string code)
		{
			IsMainPage(device);

			Helper.Click(device, 1226, 452);
			KAutoHelper.ADBHelper.Swipe(device, 828, 51, 537, 51);
			Helper.Delay(2);
			Helper.Click(device, 879, 46);
			Helper.Click(device, 755, 334);
			KAutoHelper.ADBHelper.InputText(device, code);
			Helper.Delay(1);
			Helper.Click(device, 739, 412);

			while (Helper.TuiDay(device))
			{
				MoRongTui(device);
				Helper.Click(device, 739, 412);
			}

			Helper.Click(device, 1143, 342);
			Helper.ReturnToMainpage(device, 1);
		}
		internal static void DoiLenhBai(string device)
		{
			Helper.IsMainPage(device);

			if (!Helper.IsPresent(device, Helper.BitmapFile("hoatDong")))
			{
				Helper.Click(device, 1231, 540);

			}

			if (Helper.IsPresent(device, Helper.BitmapFile("doiVatPham")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("doiVatPham"));

				int i = 1;				
				while (true)
				{
					if(i == 20)
					{
						break;
					}
					if (Helper.IsPresent(device, Helper.BitmapFile("ngocQuaLenh")))
					{
						var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
						var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Helper.BitmapFile("ngocQuaLenh"));

						Helper.Click(device, point.Value.X + 500, point.Value.Y + 20);

						KAutoHelper.ADBHelper.Tap(device, 833, 331, 8);
						Helper.Click(device, 648, 506);

						break;
					}
					else
					{
						KAutoHelper.ADBHelper.Swipe(device, 704, 514, 704, 214, 500);
						Helper.Delay(2);
						i += 1;
					}
				}
				Helper.ReturnToMainpage(device, 1);

			}

			Helper.IsMainPage(device);
		}
	}
}
