using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using BotNSHC.AutoNSHC;
using Emgu.CV.CvEnum;

namespace BotNSHC
{
	class PhucLoi
	{
		internal static void DiemDanh(string device)
		{
			Helper.IsMainPage(device);

			Helper.Click(device, 1229, 459);

			int a = 459;
			int b = 212;

			bool etat = false;
			int i = 0;
			while (!etat)
			{
				KAutoHelper.ADBHelper.Tap(device, a, b);
				Helper.Delay(2);

				var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
				var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Helper.BitmapFile("diemDanh"));
				if (point != null)
				{
					KAutoHelper.ADBHelper.Tap(device, point.Value.X, point.Value.Y);
					Helper.Delay(1);

					KAutoHelper.ADBHelper.Tap(device, 1170, 306);
					etat = true;
				}
				else
				{
					KAutoHelper.ADBHelper.Tap(device, 1170, 306);
					Helper.Delay(1);
					a += 150;
					i++;
				}
				if (i == 5)
				{
					i = 0;
					a = 459;
					b += 150;
					while (!etat)
					{
						KAutoHelper.ADBHelper.Tap(device, a, b);
						Helper.Delay(2);
						var screen1 = KAutoHelper.ADBHelper.ScreenShoot(device);
						var point1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, Helper.BitmapFile("diemDanh"));
						if (point1 != null)
						{
							KAutoHelper.ADBHelper.Tap(device, point1.Value.X, point1.Value.Y);
							Helper.Delay(1);

							KAutoHelper.ADBHelper.Tap(device, 1170, 306);
							etat = true;
						}
						else
						{
							KAutoHelper.ADBHelper.Tap(device, 1170, 306);
							Helper.Delay(1);
							a += 150;
							i++;
						}

						if (i == 5)
						{
							etat = true;
							KAutoHelper.ADBHelper.Tap(device, 1170, 306);
							Helper.Delay(2);
						}
					}
				}

			}

			Helper.ReturnToMainpage(device, 1);
		}
		internal static void RungCay(string device)
		{
			Helper.IsMainPage(device);

			Helper.Click(device, 1229, 459);
			Helper.Click(device, 790, 50);
			Helper.Click(device, 537, 604);

			Helper.ReturnToMainpage(device, 1);
		}
		internal static void RungCay5(string device)
		{
			Helper.IsMainPage(device);

			Helper.Click(device, 1229, 459);
			Helper.Click(device, 790, 50);

			for(int i = 0; i < 20; i++)
			{
				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.Tap(device, 537, 604);
				Helper.Delay(3);

				if(Helper.IsPresent(device, Helper.BitmapFile("nap")))
				{
					Helper.FindAndClick(device, Helper.BitmapFile("huy"));
					break;
				}
			}

			Helper.ReturnToMainpage(device, 1);
		}
		internal static void Tieu10V(string device)
		{
			Helper.IsMainPage(device);

			Helper.Click(device, 1229, 204);
			Helper.Click(device, 67, 268);
			Helper.Click(device, 534, 298);
			Helper.Click(device, 634, 569);
			Helper.ReturnToMainpage(device, 1);

		}
		internal static void ChiaSe(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.FindAndClick(device, Helper.BitmapFile("thoiTrang")))
			{
				
				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.Swipe(device, 839, 236, 349, 298);
				Helper.Delay(2);

				Helper.Click(device, 543, 599);
				Helper.Click(device, 654, 602);

				bool statut = false;
				while (!statut)
				{
					var screen2 = KAutoHelper.ADBHelper.ScreenShoot(device);
					var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen2, Helper.BitmapFile("fbChiaSe"));
					if (point != null)
					{
						statut = true;
					}
					Helper.Delay(2);
				}

				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.Key(device, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
				Helper.Delay(2);

				Helper.ReturnToMainpage(device, 1);

			}
		}
		internal static void TraNVChiaSe(string device)
		{
			Helper.IsMainPage(device);


			Helper.Click(device, 50, 287);

			if (MainWindow.isStop)
				return;
			var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
			var nhanPtn = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, Helper.BitmapFile("nhanXanh"), 0.8);
			if (nhanPtn.Count > 0)
			{
				foreach (var point in nhanPtn)
				{
					Helper.Click(device, point.X, point.Y);
				}
			}

			Helper.IsMainPage(device);
		}
		internal static void PhucLoi31(string device)
		{
			Helper.IsMainPage(device);

			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, 1229, 459);
			Helper.Delay(Helper.delayTime);

			int a = 454;
			for (int i = 0; i < 5; i += 1)
			{
				KAutoHelper.ADBHelper.Tap(device, a, 545);
				Helper.Delay(1);
				KAutoHelper.ADBHelper.Tap(device, 45, 257);
				Helper.Delay(1);
				a += 150;
			}

			Helper.ReturnToMainpage(device, 1);
		}
		internal static void PhucLoiT2(string device)
		{
			Helper.IsMainPage(device);

			Helper.Click(device, 1226, 542);

			if(!Helper.IsPresent(device, Helper.BitmapFile("hoatDong")))
			{
				Helper.Click(device, 1226, 542);
			}

			if (Helper.FindAndClick(device, Helper.BitmapFile("hoatDong")))
			{
				if (Helper.FindAndClick(device, Helper.BitmapFile("plqp")))
				{
					for (int i = 0; i < 3; i += 1)
					{
						var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
						var points = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, Helper.BitmapFile("nhanDo"), 0.8);
						if (points.Count > 0)
						{
							foreach (var point in points)
							{
								KAutoHelper.ADBHelper.Tap(device, point.X, point.Y);
								Helper.Delay(1);

								KAutoHelper.ADBHelper.Tap(device, 1116, 171);
								Helper.Delay(1);
							}
						}

						KAutoHelper.ADBHelper.Swipe(device, 677, 608, 677, 550);
						Helper.Delay(2);
					}
				}

				if (Helper.FindAndClick(device, Helper.BitmapFile("plv")))
				{
					for (int i = 0; i < 3; i += 1)
					{
						var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
						var points = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, Helper.BitmapFile("nhanDo"), 0.8);
						if (points.Count > 0)
						{
							foreach (var point in points)
							{
								KAutoHelper.ADBHelper.Tap(device, point.X, point.Y);
								Helper.Delay(1);

								KAutoHelper.ADBHelper.Tap(device, 1116, 171);
								Helper.Delay(1);
							}
						}

						KAutoHelper.ADBHelper.Swipe(device, 677, 608, 677, 550);
						Helper.Delay(2);
					}
				}
			}

			Helper.IsMainPage(device);
		}
		internal static void NhanThuongHoatDong(string device)
		{
			Helper.IsMainPage(device);

			Helper.Click(device, 1218, 545);

			if (Helper.FindAndClick(device, Helper.BitmapFile("hoatDong")))
			{
				int a = 300;
				int b = 150;
				for (int i = 0; i < 5; i += 1)
				{
					Helper.Click(device, a, b);

					while(Helper.IsPresent(device, Helper.BitmapFile("nhanDo")))
					{
						var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
						var points = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, Helper.BitmapFile("nhanDo"), 0.8);
						if (points.Count > 0)
						{
							foreach (var point in points)
							{
								KAutoHelper.ADBHelper.Tap(device, point.X, point.Y);
								Helper.Delay(1);

								KAutoHelper.ADBHelper.Tap(device, 1116, 171);
								Helper.Delay(1);
							}
						}

						KAutoHelper.ADBHelper.Swipe(device, 677, 608, 677, 550);
						Helper.Delay(3);
					}

					b += 100;
				}
			}
			Helper.Click(device, 1140, 77);
		}
		internal static void QuaDangNhap(string device)
		{
			Helper.IsMainPage(device);

			if(!Helper.IsPresent(device, Helper.BitmapFile("hoatDong")))
			{
				Helper.Click(device, 1231, 540);
			}

			if (Helper.IsPresent(device, Helper.BitmapFile("quaDangNhap")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("quaDangNhap"));

				Helper.FindAndClick(device, Helper.BitmapFile("nhanXanh"));

				while (Helper.TuiDay(device))
				{
					Helper.MoRongTui(device);
					Helper.FindAndClick(device, Helper.BitmapFile("nhanXanh"));
				}
				Helper.Click(device, 126, 386);
				Helper.Click(device, 1078, 77);

			}
			Helper.Click(device, 1140, 77);
		}
		internal static void ThapSangAmAp(string device)
		{
			Helper.IsMainPage(device);

			if (!Helper.IsPresent(device, Helper.BitmapFile("hoatDong")))
			{
				Helper.Click(device, 1231, 540);
			}

			if (Helper.IsPresent(device, Helper.BitmapFile("thapSangAmAp")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("thapSangAmAp"));

				int a = 322;
				int b = 322;
				for(int i = 0; i < 6; i += 1)
				{
					KAutoHelper.ADBHelper.Tap(device, a, b);
					Helper.Delay(1);
					a += 120;
				}

				Helper.Click(device, 970, 596);

				Helper.Click(device, 1124, 53);
			}

			Helper.ReturnToMainpage(device, 1);
		}
		internal static void TichLuyTieuPhi(string device)
		{
			Helper.IsMainPage(device);

			if (!Helper.IsPresent(device, Helper.BitmapFile("hoatDong")))
			{
				Helper.Click(device, 1231, 540);
			}

			if (Helper.IsPresent(device, Helper.BitmapFile("tichLuyTieuPhi")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("tichLuyTieuPhi"));

				for(int i = 0; i < 3; i += 1)
				{
					if (MainWindow.isStop)
						return;
					var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
					var points = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, Helper.BitmapFile("nhanXanh"));
					if(points.Count > 0)
					{
						foreach(var point in points)
						{
							if (MainWindow.isStop)
								return;
							KAutoHelper.ADBHelper.Tap(device, point.X, point.Y);
							Helper.Delay(Helper.delayTime);

							if (MainWindow.isStop)
								return;
							KAutoHelper.ADBHelper.Tap(device, 120, 553);
							Helper.Delay(2);
						}

						if (MainWindow.isStop)
							return;
						KAutoHelper.ADBHelper.Swipe(device, 639, 543, 639, 443, 500);
						Helper.Delay(Helper.delayTime);

					} else
					{
						break;
					}
					screen = null;
					points = null;

				}

				Helper.Click(device, 1065, 82);
			}
		}
	
		internal static void ThoiTrangSieuHot(string device)
		{
			Helper.IsMainPage(device);

			if (!Helper.IsPresent(device, Helper.BitmapFile("hoatDong")))
			{
				Helper.Click(device, 1231, 540);
			}

			if (Helper.IsPresent(device, Helper.BitmapFile("thoiTrangSieuHot")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("thoiTrangSieuHot"));


				//Helper.Click(device, 362, 214);
				//Helper.Click(device, 362, 214);

				//Helper.Click(device, 970, 214);
				//Helper.Click(device, 970, 214);

				//Helper.Click(device, 362, 378);
				//Helper.Click(device, 362, 378);

				//Helper.Click(device, 970, 378);
				//Helper.Click(device, 970, 378);

				//Helper.Click(device, 362, 551);
				//Helper.Click(device, 362, 551);

				Helper.Click(device, 970, 551);
				Helper.Click(device, 970, 551);

				Helper.Click(device, 1065, 82);
			}

			Helper.IsMainPage(device);
		}
		internal static void TuyetTrangTungBay(string device)
		{
			Helper.IsMainPage(device);

			if (!Helper.IsPresent(device, Helper.BitmapFile("hoatDong")))
			{
				Helper.Click(device, 1231, 540);
			}

			if (Helper.IsPresent(device, Helper.BitmapFile("tuyetTrangTungBay")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("tuyetTrangTungBay"));

				Helper.Click(device, 190, 209);
				Helper.Delay(2);
				while (Helper.IsPresent(device, Helper.BitmapFile("nhanXanh")))
				{
					var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
					var points = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, Helper.BitmapFile("nhanXanh"));
					if(points.Count > 0)
					{
						foreach(var point in points)
						{
							KAutoHelper.ADBHelper.Tap(device, point.X, point.Y);
							while(!Helper.IsPresent(device, Helper.BitmapFile("dongYXanh")))
							{
								Helper.Delay(1);
							}
							Helper.FindAndClick(device, Helper.BitmapFile("dongYXanh"));
						}
					}

					KAutoHelper.ADBHelper.Swipe(device, 669, 532, 669, 432, 200);
					Helper.Delay(2);
				}

				Helper.Click(device, 952, 82);
				Helper.Click(device, 1135, 42);
			}

		}
		internal static void XS20(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.FindAndClick(device, Helper.BitmapFile("bang")))
			{

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
				KAutoHelper.ADBHelper.Tap(device, 734, 448, 14);
				Helper.Delay(1);
				Helper.Click(device, 653, 534);
				Helper.Click(device, 761, 494);

				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.Tap(device, 268, 374, 5);
				Helper.Delay(Helper.delayTime);

				Helper.ReturnToMainpage(device, 2);
			}

			Helper.IsMainPage(device);
		}
		internal static void ChiemTinh10(string device)
		{
			Helper.IsMainPage(device);

			if (Helper.IsPresent(device, Helper.BitmapFile("server")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("server"));
			}
			int n = 0;
			while (!Helper.IsPresent(device, Helper.BitmapFile("quanTinhCac")))
			{
				if(n == 5)
				{
					break;
				}
				KAutoHelper.ADBHelper.Swipe(device, 938, 505, 500, 700);
				Helper.Delay(1);
				n += 1;
			}

			if (Helper.FindAndClick(device, Helper.BitmapFile("quanTinhCac")))
			{
				for (int i = 0; i < 10; i += 1)
				{
					KAutoHelper.ADBHelper.Tap(device, 422, 620);
					Helper.Delay(3);
					if(Helper.IsPresent(device, Helper.BitmapFile("dongYXanh")))
					{
						Helper.FindAndClick(device, Helper.BitmapFile("dongYXanh"));
					}
				}
				Helper.ReturnToMainpage(device, 1);
			}


		}
		internal static void BuffTTTB(string device)
		{
			Helper.IsMainPage(device);

			if (!Helper.IsPresent(device, Helper.BitmapFile("hoatDong")))
			{
				Helper.Click(device, 1231, 540);
			}

			if (Helper.IsPresent(device, Helper.BitmapFile("tuyetTrangTungBay")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("tuyetTrangTungBay"));


				//Mua Len
				Helper.Click(device, 1094, 464);
				KAutoHelper.ADBHelper.LongPress(device, 744, 483, 1000);
				Helper.Click(device, 634, 569);
				Helper.Click(device, 891, 91);

				//SuDung Len
				Helper.Click(device, 1094, 464);
				Helper.Click(device, 820, 454);
				Helper.Click(device, 623, 540);
				Helper.Click(device, 891, 91);

				Helper.Click(device, 1135, 42);
				Helper.Click(device, 1135, 42);
			}

		}
		internal static void BuffTTTBFree(string device)
		{
			Helper.IsMainPage(device);

			if (!Helper.IsPresent(device, Helper.BitmapFile("hoatDong")))
			{
				Helper.Click(device, 1231, 540);
			}

			if (Helper.IsPresent(device, Helper.BitmapFile("tuyetTrangTungBay")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("tuyetTrangTungBay"));

				Helper.Click(device, 1094, 376);
				Helper.Click(device, 820, 454);
				Helper.Click(device, 623, 540);
				Helper.Click(device, 891, 91);
				Helper.Click(device, 120, 553);

				//SuDung Len
				Helper.Click(device, 1094, 464);
				Helper.Click(device, 820, 454);
				Helper.Click(device, 623, 540);
				Helper.Click(device, 891, 91);
				Helper.Click(device, 120, 553);

				Helper.Click(device, 1135, 42);
			}

		}
	}
}
