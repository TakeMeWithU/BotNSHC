using Emgu.CV.CvEnum;
using Emgu.CV.Ocl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BotNSHC.AutoNSHC
{
	class NangDong
	{
		internal static void TraNVNgay(string device)
		{
			Helper.IsMainPage(device);

			Helper.Click(device, 56, 284);

			for (int i = 0; i < 10; i += 1)
			{
				if (MainWindow.isStop)
					return;
				var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
				var nhanPtn = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, Helper.BitmapFile("nhanXanh"), 0.8);
				if (nhanPtn.Count > 0)
				{
					if (MainWindow.isStop)
						return;
					foreach (var point in nhanPtn)
					{
						KAutoHelper.ADBHelper.Tap(device, point.X, point.Y);
						Helper.Delay(2);
					}
				}

				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.Swipe(device, 925, 588, 925, 470);
				Helper.Delay(3);
			}

			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, 322, 575);
			Helper.Delay(1);

			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, 325, 486);
			Helper.Delay(1);

			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, 327, 395);
			Helper.Delay(1);

			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, 319, 287);
			Helper.Delay(2);

			Helper.ReturnToMainpage(device, 1);
		}
		internal static void TTTT(string device)
		{
			Helper.IsMainPage(device);

			if (MainWindow.isStop)
				return;
			var server = KAutoHelper.ADBHelper.ScreenShoot(device);
			var serverPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(server, Helper.BitmapFile("server"));
			if (serverPoint != null)
			{
				KAutoHelper.ADBHelper.Tap(device, serverPoint.Value.X, serverPoint.Value.Y);
			}
			Helper.Delay(2);

			bool etat = false;
			while (!etat)
			{
				if (MainWindow.isStop)
					return;
				var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
				var truyenKy = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Helper.BitmapFile("truyenKy"));
				if (truyenKy != null)
				{
					KAutoHelper.ADBHelper.Tap(device, truyenKy.Value.X, truyenKy.Value.Y + 20);
					Helper.Delay(Helper.delayTime);
					etat = true;
				}
				else
				{
					KAutoHelper.ADBHelper.Swipe(device, 938, 505, 500, 505);
					Helper.Delay(1);
				}
			}

			Helper.Click(device, 987, 524);



			for (int i = 0; i < 2; i += 1)
			{
				Helper.Click(device, 527, 244);
				Helper.Click(device, 540, 408);
				Helper.Click(device, 761, 486);

				Helper.Click(device, 995, 403);
				Helper.Delay(2);
				Helper.Click(device, 120, 362);

			}

			Helper.IsMainPage(device);
		}
		internal static void TrieuBai(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.IsPresent(device, Helper.BitmapFile("server")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("server"));
			}

			bool etat = false;
			while (!etat)
			{
				if (Helper.IsPresent(device, Helper.BitmapFile("trieuBai")))
				{
					Helper.FindAndClick(device, Helper.BitmapFile("trieuBai"));
					etat = true;
				}
				else
				{
					KAutoHelper.ADBHelper.Swipe(device, 938, 505, 500, 505);
					Helper.Delay(1);
				}
			}

			Helper.Click(device, 532, 322);
			Helper.Click(device, 648, 534);
			Helper.Click(device, 637, 510);
			Helper.Click(device, 634, 389);
			Helper.Click(device, 634, 389);

			Helper.ReturnToMainpage(device, 2);
		}
		internal static void DauTruong(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.IsPresent(device, Helper.BitmapFile("server")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("server"));
			}

			bool etat = false;
			while (!etat)
			{
				if (Helper.IsPresent(device, Helper.BitmapFile("dauTruong")))
				{
					Helper.FindAndClick(device, Helper.BitmapFile("dauTruong"));
					etat = true;
				} else
				{
					KAutoHelper.ADBHelper.Swipe(device, 500, 505, 938, 505);
					Helper.Delay(1);
				}
			}

			Helper.Click(device, 613, 341);


			bool statut = false;
			while (!statut)
			{
				//loop
				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.Tap(device, 126, 147, 2);
				Helper.Delay(2);
				KAutoHelper.ADBHelper.Tap(device, 126, 127, 2);
				Helper.Delay(2);

				//Chon NV
				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.Tap(device, 266, 298, 2);
				Helper.Delay(2);
				KAutoHelper.ADBHelper.Tap(device, 266, 298, 2);
				Helper.Delay(5);

				if (Helper.IsPresent(device, Helper.BitmapFile("huy")))
				{
					Helper.FindAndClick(device, Helper.BitmapFile("huy"));
					break;
				}

				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.Tap(device, 266, 298, 2);
				Helper.Delay(2);
				KAutoHelper.ADBHelper.Tap(device, 779, 645);
				Helper.Delay(5);

				var screen4 = KAutoHelper.ADBHelper.ScreenShoot(device);
				var tangTocPtn = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen4, Helper.BitmapFile("tangToc"), 0.8);
				if (tangTocPtn != null)
				{
					KAutoHelper.ADBHelper.Tap(device, tangTocPtn.Value.X+10, tangTocPtn.Value.Y+10);
				}

				Helper.Click(device, 42, 645);

				bool ketThuc = false;
				while (!ketThuc)
				{
					if (Helper.FindAndClick(device, Helper.BitmapFile("dongYDo")))
					{
						ketThuc = true;
					}
				}

				Helper.Click(device, 1151, 150);
			}

			Helper.ReturnToMainpage(device, 2);

			Helper.IsMainPage(device);
		}
		internal static void KyNgoNhanh(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.FindAndClick(device, Helper.BitmapFile("kyNgo")))
			{
				Helper.Click(device, 817, 15);
				Helper.Click(device, 817, 15);
				Helper.Click(device, 631, 540);

				Helper.Click(device, 505, 292);

				Helper.Click(device, 747, 481);

				while (!Helper.IsPresent(device, Helper.BitmapFile("dongYXanh")))
				{
					Helper.Delay(1);
				}

				Helper.FindAndClick(device, Helper.BitmapFile("dongYXanh"));


				Helper.ReturnToMainpage(device, 1);
			}

		}
		internal static void TruyenKyNhanh(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.FindAndClick(device, Helper.BitmapFile("truyenKy")))
			{
				Helper.Click(device, 801, 335);

				Helper.Click(device, 532, 255);
				Helper.Click(device, 992, 400);
				Helper.Delay(3);
				Helper.Click(device, 80, 263);
				Helper.Click(device, 521, 489);

				Helper.Click(device, 680, 268);
				Helper.Click(device, 992, 400);
				Helper.Delay(3);
				Helper.Click(device, 80, 263);
				Helper.Click(device, 521, 489);

			}
			Helper.ReturnToMainpage(device, 2);

			Helper.IsMainPage(device);
		}
		internal static void QuanTruong(string device)
		{
			Helper.IsMainPage(device);

			while (!Helper.IsPresent(device, Helper.BitmapFile("quanTruong")))
			{
				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.Swipe(device, 500, 505, 938, 505);
				Helper.Delay(1);
			}

			if (MainWindow.isStop)
				return;
			if (Helper.FindAndClick(device, Helper.BitmapFile("quanTruong")))
			{
				if (MainWindow.isStop)
					return;
				var list = new List<Point>
				{
					new Point(726, 271),
					new Point(540, 283),
					new Point(822, 411),
					new Point(438, 416),
					new Point(926, 534),
					new Point(282, 532)
				};

				foreach (var point in list)
				{
					Helper.Click(device, (int)point.X, (int)point.Y);

					if (Helper.IsPresent(device, Helper.BitmapFile("nhanQuanPham")))
					{
						break;
					}
					else
					{
						if (MainWindow.isStop)
							return;
						Helper.Click(device, 1234, 41);
					}

				}

				if (MainWindow.isStop)
					return;
				if (Helper.FindAndClick(device, Helper.BitmapFile("nhanQuanPham")))
				{
					Helper.Click(device, 42, 341);
					Helper.Click(device, 419, 300);
					Helper.Click(device, 481, 349);
					Helper.Click(device, 642, 607);
					Helper.Click(device, 785, 502);
					Helper.Delay(15);
					Helper.Click(device, 640, 607);
					if (Helper.IsPresent(device, Helper.BitmapFile("huy")))
					{
						Helper.FindAndClick(device, Helper.BitmapFile("huy"));
						Helper.Click(device, 863, 88);
					}
					Helper.Click(device, 863, 88);

				}
			}
			Helper.IsMainPage(device);
		}
		internal static void NauAn(string device)
		{
			Helper.IsMainPage(device);

			

			if (MainWindow.isStop)
				return;
			if (Helper.FindAndClick(device, Helper.BitmapFile("dinhThu")))
			{
				Helper.Delay(5);

				//BanDoAN
				Helper.Click(device, 1116, 639);
				Helper.Click(device, 831, 269);
				Helper.Click(device, 814, 462);
				Helper.Click(device, 645, 532);
				Helper.Delay(3);
				Helper.Click(device, 1003, 58);

				//trong cay
				Helper.Click(device, 1207, 631);
				Helper.Click(device, 817, 53);
				Helper.Click(device, 839, 314);
				Helper.Click(device, 752, 483);
				Helper.Click(device, 631, 572);
				Helper.Click(device, (int)Helper.exitPtn.X, (int)Helper.exitPtn.Y);

				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.Swipe(device, 1213, 483, 976, 483);
				KAutoHelper.ADBHelper.Swipe(device, 1213, 483, 976, 483);
				KAutoHelper.ADBHelper.Swipe(device, 1213, 483, 976, 483);
				KAutoHelper.ADBHelper.Swipe(device, 1213, 483, 976, 483);
				KAutoHelper.ADBHelper.Swipe(device, 1213, 483, 976, 483);
				KAutoHelper.ADBHelper.Swipe(device, 1213, 483, 976, 483);
				KAutoHelper.ADBHelper.Swipe(device, 1213, 483, 976, 483);
				KAutoHelper.ADBHelper.Swipe(device, 1213, 483, 976, 483);

				Helper.Click(device, 451, 489);

				Helper.Click(device, 586, 502);
				if (MainWindow.isStop)
					return;
				int i = 0;
				while (!Helper.FindAndClick(device, Helper.BitmapFile("caiTrang")))
				{
					if (i == 3)
						break;
					Helper.FindAndClick(device, Helper.BitmapFile("quaPhai"));
					i++;
				}

				Helper.Click(device, 712, 499);

				if (Helper.IsPresent(device, Helper.BitmapFile("caiTrang")))
					if (MainWindow.isStop)
						return;
				i = 0;
				while (!Helper.FindAndClick(device, Helper.BitmapFile("caiTrang")))
				{
					if (i == 3)
						break;
					Helper.FindAndClick(device, Helper.BitmapFile("quaPhai"));
					i++;
				}

				//Nau an
				Helper.Click(device, 653, 120);
				Helper.Click(device, 653, 120);

				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.Swipe(device, 435, 228, 438, 459);
				KAutoHelper.ADBHelper.Swipe(device, 435, 228, 438, 459);
				KAutoHelper.ADBHelper.Swipe(device, 435, 228, 438, 459);
				KAutoHelper.ADBHelper.Swipe(device, 435, 228, 438, 459);
				KAutoHelper.ADBHelper.Swipe(device, 435, 228, 438, 459);
				KAutoHelper.ADBHelper.Swipe(device, 435, 228, 438, 459);
				KAutoHelper.ADBHelper.Swipe(device, 435, 228, 438, 459);
				KAutoHelper.ADBHelper.Swipe(device, 435, 228, 438, 459);

				Helper.Delay(2);

				Helper.Click(device, 432, 335);
				Helper.Click(device, 602, 599);
				Helper.Click(device, 836, 349);
				Helper.Click(device, 650, 512);

				Helper.Click(device, 650, 494);
				Helper.Click(device, 650, 494);

				Helper.ReturnToMainpage(device, 2);
			}

			Helper.IsMainPage(device);
		}
		internal static void CuongHoaThoiTrang(string device)
		{
			Helper.IsMainPage(device);

			if (MainWindow.isStop)
				return;
			if (Helper.FindAndClick(device, Helper.BitmapFile("thoiTrang")))
			{
				Helper.Click(device, 742, 50);
				Helper.Click(device, 753, 521);
				Helper.Click(device, 572, 320);
				Helper.Click(device, 742, 319);
				Helper.Click(device, 989, 604);

				Helper.Click(device, 1140, 47);
				Helper.Click(device, 1140, 47);
				Helper.Click(device, 1140, 47);

				Helper.ReturnToMainpage(device, 1);

			}
		}
		internal static void ThaoTrangBi(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.FindAndClick(device, Helper.BitmapFile("doiHinh")))
			{
				Helper.Click(device, 572, 497);
				Helper.Click(device, 742, 623);

				Helper.ReturnToMainpage(device, 2);
			}

			Helper.IsMainPage(device);
		}
		internal static void MacTrangBi(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.FindAndClick(device, Helper.BitmapFile("doiHinh")))
			{
				Helper.Click(device, 572, 497);
				Helper.Click(device, 613, 626);

				Helper.ReturnToMainpage(device, 2);
			}

			Helper.IsMainPage(device);
		}
		internal static void CuongHoaTrangBi(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.FindAndClick(device, Helper.BitmapFile("doiHinh")))
			{
				Helper.Click(device, 572, 497);
				Helper.Click(device, 879, 631);

				Helper.Click(device, 1038, 634);
				Helper.Delay(5);
				Helper.Click(device, 1038, 634);

				Helper.ReturnToMainpage(device, 3);
			}

			Helper.IsMainPage(device);
		}
		internal static void DonDuocTaiNghe(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.FindAndClick(device, Helper.BitmapFile("doiHinh")))
			{
				Helper.Click(device, 572, 497);

				KAutoHelper.ADBHelper.Swipe(device, 1135, 564, 1135, 333);
				KAutoHelper.ADBHelper.Swipe(device, 1135, 564, 1135, 333);
				KAutoHelper.ADBHelper.Swipe(device, 1135, 564, 1135, 333);

				if (Helper.FindAndClick(device, Helper.BitmapFile("taiNghe")))
				{
					KAutoHelper.ADBHelper.Tap(device, 478, 222);
					KAutoHelper.ADBHelper.Tap(device, 917, 53);
					Helper.Delay(1);

					Helper.Click(device, 559, 357);
					Helper.Click(device, 995, 620);

					Helper.ReturnToMainpage(device, 2);
				}


				if (Helper.FindAndClick(device, Helper.BitmapFile("donDuoc")))
				{
					Helper.Click(device, 911, 182);
					Helper.Click(device, 1035, 448);
					Helper.Click(device, 1024, 553);

					Helper.Click(device, 906, 295);
					Helper.Click(device, 1035, 448);
					Helper.Click(device, 1024, 553);

					Helper.Click(device, 956, 68);
				}

				Helper.ReturnToMainpage(device, 3);
			}

			Helper.IsMainPage(device);
		}
		internal static void NenMua(string device)
		{
			Helper.IsMainPage(device);

			Helper.Click(device, 1223, 204);
			Helper.Click(device, 77, 268);
			Helper.Click(device, 903, 306);
			Helper.Click(device, 653, 567);

			Helper.ReturnToMainpage(device, 1);

			Helper.IsMainPage(device);
		}
		internal static void ThiDauLePhuc(string device)
		{
			Helper.IsMainPage(device);

			while (!Helper.IsPresent(device, Helper.BitmapFile("lePhuc")))
			{
				KAutoHelper.ADBHelper.Swipe(device, 938, 505, 500, 505);
				Helper.Delay(1);
			}

			if (Helper.FindAndClick(device, Helper.BitmapFile("lePhuc")))
			{
				Helper.Click(device, 814, 333);
				for (int i = 0; i < 3; i += 1)
				{

					Helper.Click(device, 634, 540);


					KAutoHelper.ADBHelper.Tap(device, 642, 351);
					KAutoHelper.ADBHelper.Tap(device, 642, 351);
					KAutoHelper.ADBHelper.Tap(device, 642, 351);
					Helper.Click(device, 642, 351);


					KAutoHelper.ADBHelper.Tap(device, (int)Helper.exitPtn.X, (int)Helper.exitPtn.Y, 3);

					while (!Helper.IsPresent(device, Helper.BitmapFile("thoiTrang")))
					{
						Helper.Click(device, 540, 594);
						KAutoHelper.ADBHelper.Tap(device, 50, 300);
					}
				}
			}

			Helper.IsMainPage(device);
		}
		internal static void ThamDinhThu(string device)
		{
			Helper.IsMainPage(device);

			if(Helper.IsPresent(device, Helper.BitmapFile("dinhThu")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("dinhThu"));

				if (Helper.IsPresent(device, Helper.BitmapFile("danhSach")))
				{
					Helper.FindAndClick(device, Helper.BitmapFile("danhSach"));

					if (Helper.IsPresent(device, Helper.BitmapFile("diDenXanh")))
					{
						Helper.FindAndClick(device, Helper.BitmapFile("diDenXanh"));

						Helper.Click(device, 801, 265);
						Helper.Delay(5);

						if (Helper.IsPresent(device, Helper.BitmapFile("roiXanh")))
						{
							Helper.FindAndClick(device, Helper.BitmapFile("roiXanh"));
							Helper.Click(device, 817, 483);
						}

						Helper.FindAndClick(device, Helper.BitmapFile("thamXanh"));
						Helper.Delay(1);
						Helper.Click(device, 720, 502);

						Helper.ReturnToMainpage(device, 1);
					} else
					{
						Helper.Click(device, 919, 53);
						Helper.Click(device, 48, 177);
						Helper.Click(device, 185, 499);

						Helper.Click(device, 77, 217);

						Helper.Click(device, 801, 265);

						while (true)
						{
							if(Helper.IsPresent(device, Helper.BitmapFile("thamXanh")))
							{
								Helper.FindAndClick(device, Helper.BitmapFile("thamXanh"));
								Helper.Delay(1);
								Helper.Click(device, 720, 502);
								Helper.ReturnToMainpage(device, 1);
								break;
							}
							Helper.ReturnToMainpage(device, 1);
							Helper.Click(device, 75, 612);
							Helper.Click(device, 77, 217);

							Helper.Click(device, 801, 265);
						}
					}
				}

				Helper.ReturnToMainpage(device, 1);
			}
		}
	}
}
