using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using BotNSHC.AutoNSHC;
using Emgu.CV.CvEnum;
using MaterialDesignThemes.Wpf;

namespace BotNSHC
{
	class Bang
	{
		internal static void VoBang(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.FindAndClick(device, Helper.BitmapFile("bang")))
			{
				Helper.Delay(1);
				Helper.Click(device, 798, 634);
				Helper.Click(device, 683, 335);

				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + device + " shell input keyevent 279");
				Helper.Delay(Helper.delayTime);

				Helper.Click(device, 642, 427);
				Helper.Click(device, 1040, 128);
				Helper.Click(device, (int)Helper.exitPtn.X, (int)Helper.exitPtn.Y);
			}
			
			Helper.IsMainPage(device);
		}
		internal static void RoiBang(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.FindAndClick(device, Helper.BitmapFile("bang")))
			{
				Helper.Delay(1);
				Helper.Click(device, 1081, 615);
				Helper.Click(device, 995, 47);
				Helper.Click(device, 761, 491);
			}

			Helper.IsMainPage(device);
		}
		internal static void GopMax(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.FindAndClick(device, Helper.BitmapFile("bang")))
			{
				Helper.Delay(1);
				Helper.Click(device, 1170, 618);
				Helper.Click(device, 987, 524);
				Helper.Click(device, 825, 438);

				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.LongPress(device, 545, 440, 1600);
				Helper.Delay(Helper.delayTime);

				Helper.Click(device, 640, 529);
				Helper.Click(device, 761, 491);
				Helper.Click(device, (int)Helper.exitPtn.X, (int)Helper.exitPtn.Y);
				Helper.Click(device, (int)Helper.exitPtn.X, (int)Helper.exitPtn.Y);
			}

		}
		internal static void MuaLenh(string device)
		{
			Helper.IsMainPage(device);

			if (MainWindow.isStop)
				return;
			if (Helper.FindsAndClicks(device, Helper.BitmapFile("bang")))
			{
				Helper.Delay(1);
				Helper.Click(device, 1043, 413);

				Helper.Click(device, 564, 360);

				if (Helper.IsPresent(device, Helper.BitmapFile("KPPL")))
				{
					var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
					var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Helper.BitmapFile("KPPL"));
					if (point != null)
					{
						Helper.Click(device, point.Value.X, point.Value.Y + 180);

						KAutoHelper.ADBHelper.Tap(device, 750, 481, 8);

						Helper.Click(device, 642, 577);

						Helper.Click(device, 1106, 96);
					}
				}
				else
				{
					Helper.Click(device, 809, 634);
					var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
					var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Helper.BitmapFile("KPPL"));
					if (point != null)
					{
						Helper.Click(device, point.Value.X, point.Value.Y + 180);

						KAutoHelper.ADBHelper.Tap(device, 750, 481, 8);

						Helper.Click(device, 642, 577);

						Helper.Click(device, 1106, 96);
					}
				}
				Helper.Click(device, 882, 88);

				Helper.ReturnToMainpage(device, 2);
			}

			Helper.IsMainPage(device);
		}
		internal static void ThanQQ(string device, int qq)
		{
			Helper.IsMainPage(device);
			if (Helper.FindAndClick(device, Helper.BitmapFile("bang")))
			{
				Helper.Delay(1);
				Helper.Click(device, 761, 453);
				Helper.Click(device, 564, 357);

				//qq
				ChonQQ(device, qq);
				Helper.Delay(1);

				if (!Helper.FindAndClick(device, Helper.BitmapFile("than")))
				{
					Helper.Click(device, 529, 637);
				}

				Helper.Click(device, 863, 169);
				Helper.Click(device, 857, 588);
				Helper.Click(device, 742, 462);
				Helper.Click(device, 637, 537);

			}

			Helper.ReturnToMainpage(device, 4);
			Helper.IsMainPage(device);
		}
		internal static void ThanQQMax(string device, int qq)
		{
			Helper.IsMainPage(device);
			if (Helper.FindAndClick(device, Helper.BitmapFile("bang")))
			{
				Helper.Delay(1);
				Helper.Click(device, 761, 453);
				Helper.Click(device, 564, 357);

				//qq
				ChonQQ(device, qq);
				Helper.Delay(1);

				if (!Helper.FindAndClick(device, Helper.BitmapFile("than")))
				{
					Helper.Click(device, 529, 637);
				}

				Helper.Click(device, 863, 169);

				while (true)
				{
					if (MainWindow.isStop)
						break;
					KAutoHelper.ADBHelper.Tap(device, 857, 588);
					Helper.Delay(2);

					if (MainWindow.isStop)
						break;
					KAutoHelper.ADBHelper.Tap(device, 822, 464);
					Helper.Delay(2);
					if (!Helper.IsPresent(device, Helper.BitmapFile("dongYXanh")))
					{
						break;
					}
					if (MainWindow.isStop)
						break;
					KAutoHelper.ADBHelper.Tap(device, 637, 537);
					Helper.Delay(3);

					if (MainWindow.isStop)
						break;
					KAutoHelper.ADBHelper.Tap(device, 857, 588);
					Helper.Delay(2);
				}

			}

			Helper.ReturnToMainpage(device, 4);
			Helper.IsMainPage(device);
		}
		internal static void ChonQQ(string device, int number)
		{
			Bitmap qq1 = null;
			Bitmap qq2 = null;
			
			switch (number)
			{
				case 1:
					qq1 = Helper.BitmapFile("QQ//1anhCach");
					break;
				case 2:
					qq1 = Helper.BitmapFile("QQ//2lieuThaiY");
					break;
				case 3:
					qq1 = Helper.BitmapFile("QQ//3batVuongGia");
					break;
				case 4:
					qq1 = Helper.BitmapFile("QQ//4huePhi");
					qq2 = Helper.BitmapFile("QQ//4huePhi2");
					break;
				case 5:
					qq1 = Helper.BitmapFile("QQ//5ninhPhi");
					break;
				case 6:
					qq1 = Helper.BitmapFile("QQ//6hiPhi");
					break;
				case 7:
					qq1 = Helper.BitmapFile("QQ//7diThanVuong");
					break;
				case 8:
					qq1 = Helper.BitmapFile("QQ//8nienPhu");
					break;
				case 9:
					qq1 = Helper.BitmapFile("QQ//9onQuyNhan");
					break;
				case 10:
					qq1 = Helper.BitmapFile("QQ//10nhiHoangTu");
					break;
				case 11:
					qq1 = Helper.BitmapFile("QQ//11canPhi");
					break;
				case 12:
					qq1 = Helper.BitmapFile("QQ//12leTan");
					break;
				case 13:
					qq1 = Helper.BitmapFile("QQ//13thanhPhi");
					break;
				case 14:
					qq1 = Helper.BitmapFile("QQ//14tueQuyNhan");
					break;
				case 15:
					qq1 = Helper.BitmapFile("QQ//15diepQuyNhan");
					break;
				case 16:
					qq1 = Helper.BitmapFile("QQ//15diepQuyNhan");
					break;

			}

			bool value = false;
			do
			{
				if (MainWindow.isStop)
					return;
				if (Helper.IsPresent(device, qq1))
				{
					var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
					var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, qq1, 0.7);
					if (point != null)
					{
						KAutoHelper.ADBHelper.Tap(device, point.Value.X, point.Value.Y);
						Helper.Delay(2);
						value = true;
					}
				}
				else
				{
					if (MainWindow.isStop)
						return;
					KAutoHelper.ADBHelper.Swipe(device, 271, 551, 271, 470);
					Helper.Delay(3);
				}

			} while (!value);
		}
		internal static void GopBang(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.FindAndClick(device, Helper.BitmapFile("bang")))
			{
				Helper.Delay(1);
				Helper.Click(device, 1170, 618);
				Helper.Click(device, 753, 516);
				Helper.Click(device, 750, 491);

				Helper.ReturnToMainpage(device, 2);
			}

			Helper.IsMainPage(device);
		}
		internal static void Bong(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.FindAndClick(device, Helper.BitmapFile("bang")))
			{
				Helper.Delay(1);
				Helper.Click(device, 1073, 620);

				if (Helper.FindAndClick(device, Helper.BitmapFile("tuongTacXanh")))
				{
					Helper.Click(device, 750, 376);
					Helper.Delay(1);
					Helper.Click(device, 839, 620);

					Helper.ChonBong(device, Helper.BitmapFile("Bong//hoaHong1Doa"));
					Helper.ChonBong(device, Helper.BitmapFile("Bong//hoaHong1Doa"));

					Helper.ReturnToMainpage(device, 3);
				}
				Helper.ReturnToMainpage(device, 2);
			}
		}
		internal static void Dtxs(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.FindAndClick(device, Helper.BitmapFile("bang")))
			{
				Helper.Delay(1);
				Helper.Click(device, 621, 263);
				Helper.Click(device, 564, 314);
				Helper.Click(device, 532, 604);

				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.InputText(device, "vip09906");
				Helper.Delay(Helper.delayTime);


				Helper.Click(device, 852, 610);
				Helper.Click(device, 852, 610);
				Helper.Click(device, 634, 163);

				//XS
				Helper.Click(device, 513, 577);
				Helper.Click(device, 486, 532);
				Helper.Click(device, 653, 534);
				Helper.Click(device, 761, 494);
				Helper.Click(device, 852, 610);
				Helper.Click(device, 852, 610);

				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.Tap(device, 268, 374, 10);
				Helper.Delay(Helper.delayTime);


				//DT
				Helper.Click(device, 852, 610);
				Helper.Click(device, 634, 163);
				Helper.Click(device, 711, 572);
				Helper.Click(device, 486, 532);
				Helper.Click(device, 653, 534);
				Helper.Click(device, 761, 494);

				Helper.ReturnToMainpage(device, 3);
			}

			Helper.IsMainPage(device);
		}
		internal static void ViengTham(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.FindAndClick(device, Helper.BitmapFile("cungDau")))
			{
				Helper.Delay(1);
				Helper.Click(device, 1151, 362);
				Helper.Click(device, 306, 357);
				
				for (int i = 0; i < 10; i++)
				{
					if (MainWindow.isStop)
						return;
					KAutoHelper.ADBHelper.Tap(device, 562, 254);
					Helper.Delay(1);
				}

				Helper.ReturnToMainpage(device, 2);
			}

			Helper.IsMainPage(device);
		}
		internal static void TraNV(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.FindAndClick(device, Helper.BitmapFile("bang")))
			{
				Helper.Delay(1);
				Helper.Click(device, 344, 381);
				Helper.Click(device, 562, 365);
				Helper.Click(device, 1016, 583);
				Helper.Delay(5);
				Helper.Click(device, 645, 588);

				Helper.ReturnToMainpage(device, 2);
			}
			Helper.IsMainPage(device);
		}
		internal static void Phat5NVBang(string device)
		{
			Helper.IsMainPage(device);

			if (MainWindow.isStop)
				return;
			if (Helper.FindAndClick(device, Helper.BitmapFile("bang")))
			{
				Helper.Delay(1);
				Helper.Click(device, 354, 403);
				
				if (MainWindow.isStop)
					return;
				if (Helper.FindAndClick(device, Helper.BitmapFile("vao")))
				{
					Helper.Click(device, 645, 583);
					var list = new List<Bitmap>
						{
							(Bitmap)Bitmap.FromFile("Data//nvGopBac.png"),
							(Bitmap)Bitmap.FromFile("Data//nvHaoHuu.png"),
							(Bitmap)Bitmap.FromFile("Data//nvCungDau.png"),
						};

					for (int i = 0; i < 2; i += 1)
					{
						var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
						foreach (var value in list)
						{
							var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, value);
							if (point != null)
							{
								if (MainWindow.isStop)
									return;
								KAutoHelper.ADBHelper.Tap(device, point.Value.X + 820, point.Value.Y + 25);
								Helper.Delay(2);
							}
						}
						KAutoHelper.ADBHelper.Swipe(device, 766, 559, 766, 271);
						Helper.Delay(2);
					}
				}
			}
			Helper.IsMainPage(device);
		}
		internal static void Phat6NVBang(string device)
		{
			Helper.IsMainPage(device);

			if (MainWindow.isStop)
				return;
			if (Helper.FindAndClick(device, Helper.BitmapFile("bang")))
			{
				Helper.Delay(1);
				Helper.Click(device, 354, 403);

				if (MainWindow.isStop)
					return;
				if (Helper.FindAndClick(device, Helper.BitmapFile("vao")))
				{
					Helper.Click(device, 645, 583);
					var list = new List<Bitmap>
						{
							(Bitmap)Bitmap.FromFile("Data//nvGopBac.png"),
							(Bitmap)Bitmap.FromFile("Data//nvHaoHuu.png"),
							(Bitmap)Bitmap.FromFile("Data//nvCungDau.png"),
							(Bitmap)Bitmap.FromFile("Data//nvQQ.png"),
						};

					for (int i = 0; i < 2; i += 1)
					{
						var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
						foreach (var value in list)
						{
							var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, value);
							if (point != null)
							{
								if (MainWindow.isStop)
									return;
								KAutoHelper.ADBHelper.Tap(device, point.Value.X + 820, point.Value.Y + 25);
								Helper.Delay(2);
							}
						}
						KAutoHelper.ADBHelper.Swipe(device, 766, 559, 766, 271);
						Helper.Delay(2);
					}
				}
			}
			Helper.IsMainPage(device);
		}
		internal static void Phat8NVBang(string device)
		{
			Helper.IsMainPage(device);

			if (MainWindow.isStop)
				return;
			if (Helper.FindAndClick(device, Helper.BitmapFile("bang")))
			{
				Helper.Delay(1);
				Helper.Click(device, 354, 403);

				if (MainWindow.isStop)
					return;
				if (Helper.FindAndClick(device, Helper.BitmapFile("vao")))
				{
					Helper.Click(device, 645, 583);
					var list = new List<Bitmap>
						{
							(Bitmap)Bitmap.FromFile("Data//nvGopBac.png"),
							(Bitmap)Bitmap.FromFile("Data//nvHaoHuu.png"),
							(Bitmap)Bitmap.FromFile("Data//nvCungDau.png"),
							(Bitmap)Bitmap.FromFile("Data//nvQQ.png"),
							(Bitmap)Bitmap.FromFile("Data//nvDT.png"),
							(Bitmap)Bitmap.FromFile("Data//nvXS.png"),
						};

					for (int i = 0; i < 2; i += 1)
					{
						var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
						foreach (var value in list)
						{
							var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, value);
							if (point != null)
							{
								if (MainWindow.isStop)
									return;
								KAutoHelper.ADBHelper.Tap(device, point.Value.X + 820, point.Value.Y + 25);
								Helper.Delay(2);
							}
						}
						KAutoHelper.ADBHelper.Swipe(device, 766, 559, 766, 271);
						Helper.Delay(2);
					}
				}
			}
			Helper.IsMainPage(device);
		}
		internal static void BanBe(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.FindAndClick(device, Helper.BitmapFile("bang")))
			{
				Helper.Delay(1);
				Helper.Click(device, 1073, 620);

				var tuongTac = KAutoHelper.ADBHelper.ScreenShoot(device);
				var tuongTacPoints = KAutoHelper.ImageScanOpenCV.FindOutPoints(tuongTac, Helper.BitmapFile("tuongTacXanh"));
				while (tuongTacPoints.Count > 0)
				{
					var point = tuongTacPoints[0];
					tuongTacPoints.RemoveAt(0);

					Helper.Click(device, point.X, point.Y);

					Helper.Click(device, 457, 373);
					Helper.Click(device, 648, 620);
				}

				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.Swipe(device, 653, 524, 653, 402);
				Helper.Delay(Helper.delayTime);

				tuongTac = KAutoHelper.ADBHelper.ScreenShoot(device);
				tuongTacPoints = KAutoHelper.ImageScanOpenCV.FindOutPoints(tuongTac, Helper.BitmapFile("tuongTacXanh"));
				while (tuongTacPoints.Count > 0)
				{
					var point = tuongTacPoints[0];
					tuongTacPoints.RemoveAt(0);

					Helper.Click(device, point.X, point.Y);

					Helper.Click(device, 457, 373);
					Helper.Click(device, 648, 620);
				}

				Helper.Click(device, (int)Helper.exitPtn.X, (int)Helper.exitPtn.Y);
				Helper.Click(device, (int)Helper.exitPtn.X, (int)Helper.exitPtn.Y);
			}
		}
		internal static void DongYKB(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.FindAndClick(device, Helper.BitmapFile("tuongTac")))
			{
				if (Helper.FindAndClick(device, Helper.BitmapFile("haoHuu")))
				{
					Helper.Click(device, 171, 300);
					Helper.Click(device, 871, 661);
				}
				Helper.ReturnToMainpage(device, 1);
			}
			Helper.IsMainPage(device);

		}
		internal static void SuDungMienTuBai(string device)
		{
			Helper.IsMainPage(device);

			if(Helper.FindAndClick(device, Helper.BitmapFile("bang")))
			{
				Helper.Delay(1);
				Helper.Click(device, 465, 269);
				Helper.Click(device, 567, 314);
				Helper.Click(device, 56, 182);
				Helper.Click(device, 247, 467);
				Helper.Click(device, 640, 567);
				Helper.Click(device, 247, 467);

				Helper.ReturnToMainpage(device, 3);
			}
			Helper.IsMainPage(device);
		}
		internal static void IsInBang(string device)
		{
			Helper.IsMainPage(device);

			if (MainWindow.isStop)
				return;
			if (Helper.FindAndClick(device, Helper.BitmapFile("bang")))
			{
				Helper.Delay(1);
				while (true)
				{
					if(Helper.IsPresent(device, Helper.BitmapFile("thanhVien")))
					{
						break;
					}
				}

				Helper.ClickOutPoint(device);
			}
			Helper.IsMainPage(device);
		}
		internal static void ThinhAn(string device)
		{
			Helper.IsMainPage(device);

			if(Helper.FindAndClick(device, Helper.BitmapFile("bang")))
			{
				Helper.Delay(1);
				if (Helper.FindAndClick(device, Helper.BitmapFile("thanhVien")))
				{
					var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
					var points = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, Helper.BitmapFile("tuongTacXanh"));
					if (points.Count > 0)
					{
						foreach(var point in points)
						{
							Helper.Click(device, point.X, point.Y);
							Helper.Click(device, 753, 378);
							Helper.Click(device, 946, 612);
							if (Helper.IsPresent(device, Helper.BitmapFile("dongYXanh")))
							{
								Helper.FindAndClick(device, Helper.BitmapFile("dongYXanh"));

							}
							Helper.Click(device, 1191, 381);
							Helper.ReturnToMainpage(device, 2);
						}
					}
					Helper.ReturnToMainpage(device, 2);
				}
			}
			Helper.IsMainPage(device);
		}
	}
}
