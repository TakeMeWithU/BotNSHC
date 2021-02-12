using Emgu.CV.Ocl;
using KAutoHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xaml;

namespace BotNSHC.AutoNSHC
{
	class Level
	{
		private static void BoQuaTron(string device)
		{
			
			bool statut = false;
			int i = 0;
			while (!statut)
			{
				if (i == 7)
				{
					ClickMiddle(device);
				}
				if (Helper.IsPresent(device, Helper.BitmapFile("boQuaTron")))
				{
					var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
					var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Helper.BitmapFile("boQuaTron"), 0.8);
					if(point != null)
					{
						KAutoHelper.ADBHelper.Tap(device, point.Value.X+5, point.Value.Y+5);
						Helper.Delay(2);
					}
					statut = true;
				}
				i++;
			}
		}
		private static void BoQua(string device)
		{
			bool statut = false;
			while (!statut)
			{
				if (Helper.IsPresent(device, Helper.BitmapFile("boQua")))
				{
					var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
					var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Helper.BitmapFile("boQua"), 0.8);
					if (point != null)
					{
						KAutoHelper.ADBHelper.Tap(device, point.Value.X, point.Value.Y);
						Helper.Delay(2);
					}
					statut = true;
				}
			}
		}
		private static void DongYXanh(string device)
		{
			bool statut = false;
			while (!statut)
			{
				if (Helper.IsPresent(device, Helper.BitmapFile("dongYXanh")))
				{
					var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
					var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Helper.BitmapFile("dongYXanh"), 0.8);
					if (point != null)
					{
						KAutoHelper.ADBHelper.Tap(device, point.Value.X+5, point.Value.Y+5);
						Helper.Delay(3);
					}
					statut = true;
				}
			}
		}
		private static void IfDongYXanh(string device)
		{
			if (Helper.IsPresent(device, Helper.BitmapFile("dongYXanh")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("dongYXanh"));
			}
		}
		private static void DongYDo(string device)
		{
			bool statut = false;
			while (!statut)
			{
				if (Helper.IsPresent(device, Helper.BitmapFile("dongYDo")))
				{
					var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
					var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Helper.BitmapFile("dongYDo"), 0.8);
					if (point != null)
					{
						KAutoHelper.ADBHelper.Tap(device, point.Value.X, point.Value.Y);
						Helper.Delay(3);
					}
					statut = true;
				}
			}
		}
		private static void KetThucDo(string device)
		{
			bool statut = false;
			while (!statut)
			{
				if (Helper.IsPresent(device, Helper.BitmapFile("ketThucDo")))
				{
					var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
					var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Helper.BitmapFile("ketThucDo"), 0.8);
					if (point != null)
					{
						KAutoHelper.ADBHelper.Tap(device, point.Value.X+5, point.Value.Y+5);
						Helper.Delay(2);
					}
					statut = true;
				}
			}
		}
		private static void DongDo(string device)
		{
			bool statut = false;
			while (!statut)
			{
				if (Helper.IsPresent(device, Helper.BitmapFile("dongDo")))
				{
					var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
					var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Helper.BitmapFile("dongDo"), 0.8);
					if (point != null)
					{
						KAutoHelper.ADBHelper.Tap(device, point.Value.X+5, point.Value.Y+5);
						Helper.Delay(3);
					}
					statut = true;
				}
			}
		}
		private static void ClickNV(string device)
		{
			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, 56, 209);
			Helper.Delay(2);
		}
		private static void DiDen(string device)
		{
			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, 825, 634);
			Helper.Delay(2);
		}
		private static void ChonNPC(string device)
		{
			bool statut = false;
			while (!statut)
			{
				var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
				var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Helper.BitmapFile("nv"), 0.5);
				if (point != null)
				{
					KAutoHelper.ADBHelper.Tap(device, point.Value.X + 10, point.Value.Y + 50);
					Helper.Delay(3);
					statut = true;
				}
			}
		}
		private static void PhoBanNV(string device, int a, int b)
		{
			Helper.Click(device, a, b);
			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, 860, 542);
			Helper.Delay(2);
			KetThucDo(device);
			

		}
		private static void ClickMiddle(string device)
		{
			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, 634, 292, 2);
			Helper.Delay(2);
			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, 634, 292, 2);
			Helper.Delay(2);
		}
		private static void ClickLeft(string device, int i)
		{
			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, 120, 553, i);
			Helper.Delay(2);
		}
		private static void KyNgo(string device, int i)
		{
			

			for(int n = 0; n < i; n += 1)
			{
				Helper.Click(device, 874, 120);
				Helper.Delay(2);
				while (!Helper.IsPresent(device, Helper.BitmapFile("conv")))
				{
					if (Helper.IsPresent(device, Helper.BitmapFile("exitPtn")))
					{
						Helper.ClickOutPoint(device);
					}
					else
					{
						KAutoHelper.ADBHelper.Tap(device, 478, 117);
						KAutoHelper.ADBHelper.Tap(device, 857, 112);
						Helper.Delay(3);
					}
				}

				KAutoHelper.ADBHelper.Tap(device, 212, 39, 5);
				Helper.Delay(2);
			}

			Helper.IsMainPage(device);
		}
		internal static void Login(string device, User user)
		{
			bool statut = false;
			int i = 0;
			do
			{
				if (i == 5)
				{
					Helper.IsMainPage(device);
					Helper.Logout(device);
				}
				if (!Helper.IsPresent(device, Helper.BitmapFile("dongYXanh")))
				{
					Helper.Delay(Helper.delayTime);
					i++;
				}
				else
				{
					statut = true;
					Helper.Click(device, 637, 647);
				}

			} while (statut != true);


			statut = false;
			i = 0;
			do
			{
				if (!Helper.IsPresent(device, Helper.BitmapFile("zing")))
				{
					Helper.Delay(Helper.delayTime);
					i += 1;
				}
				else
				{
					statut = true;
				}
				if (i == 10)
				{
					Helper.Click(device, 640, 602);
				}
			} while (statut != true);

			Helper.Click(device, 642, 362);

			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, 822, 300);
			Helper.Delay(1);
			for (int n = 0; n < 25; n++)
			{
				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.Key(device, KAutoHelper.ADBKeyEvent.KEYCODE_DEL);
			}

			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.InputText(device, user.Username.ToString());
			Helper.Delay(1);


			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, 615, 360);
			Helper.Delay(1);
			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.InputText(device, user.Password.ToString());
			Helper.Delay(1);

			if (MainWindow.isStop)
				return;
			KAutoHelper.ADBHelper.Tap(device, 637, 435, 2);
			Helper.Delay(Helper.delayTime);

			if (user.Server != 0)
			{

				Helper.ChonServer(device, user.Server);

			}

			Helper.Click(device, 640, 602);
			Helper.Click(device, 640, 602);
		}
		internal static void DatTen(string device, string ten)
		{
			bool statut = false;
			while (!statut)
			{
				if (Helper.IsPresent(device, Helper.BitmapFile("nu")))
				{
					statut = true;
					Helper.Delay(15);
				}
			}

			Helper.Click(device, 704, 677);

			for (int n = 0; n < 25; n++)
			{
				if (MainWindow.isStop)
					return;
				KAutoHelper.ADBHelper.Key(device, KAutoHelper.ADBKeyEvent.KEYCODE_DEL);
			}

			KAutoHelper.ADBHelper.InputText(device, ten);
			Helper.Delay(2);

			Helper.Click(device, 1202, 647);
			Helper.Delay(2);

			statut = false;
			int i = 0;
			while (!statut)
			{
				if(i == 7)
				{
					if (Helper.IsPresent(device, Helper.BitmapFile("nu")))
					{
						Helper.Click(device, 704, 677);
						KAutoHelper.ADBHelper.InputText(device, "a");
						Helper.Click(device, 1202, 647);
					}
				}
				if (!Helper.IsPresent(device, Helper.BitmapFile("muiTenXanh")))
				{
					i += 1;
				} else
				{
					statut = true;
				}
			}
		}

		internal static void LV1toLV11(string device)
		{
			//lv1
			bool statut = false;
			while (!statut)
			{
				if (Helper.IsPresent(device, Helper.BitmapFile("muiTenXanh")))
				{
					statut = true;
				}
			}

			ClickMiddle(device);
			ClickMiddle(device);
			ClickMiddle(device);
			BoQua(device);
			ClickMiddle(device);
			BoQuaTron(device);
			ClickMiddle(device);
			ClickMiddle(device);
			//LV2
			DongYXanh(device);
			BoQua(device);
			BoQuaTron(device);
			BoQuaTron(device);
			ClickMiddle(device);
			ClickMiddle(device);
			KAutoHelper.ADBHelper.Tap(device, 640, 292, 50);
			ClickMiddle(device);
			ClickMiddle(device);
			//LV4
			DongYXanh(device);
			BoQuaTron(device);
			ClickMiddle(device);
			KetThucDo(device);
			DongYDo(device);
			ClickMiddle(device);
			ClickMiddle(device); 
			ClickMiddle(device);
			ClickMiddle(device);
			BoQua(device);
			BoQua(device);
			BoQua(device);
			BoQuaTron(device);
			ClickMiddle(device);
			ClickMiddle(device);
			BoQua(device);
			//LV6
			DongYXanh(device);
			BoQuaTron(device);
			ClickMiddle(device);
			//LV7
			DongYXanh(device);
			BoQua(device);
			//LV8
			DongYXanh(device);
			KAutoHelper.ADBHelper.Tap(device, 120, 553, 30);
			ClickMiddle(device);
			ClickMiddle(device);
			//LV11
			DongYXanh(device);
			BoQua(device);
			ClickMiddle(device);
			Helper.IsMainPage(device);

			Helper.FindAndClick(device, Helper.BitmapFile("doiHinh"));
			Helper.Click(device, 473, 53);
			Helper.Click(device, 1067, 542);
			KAutoHelper.ADBHelper.Tap(device, 1013, 271, 1);
			Helper.Delay(2);
			KAutoHelper.ADBHelper.Tap(device, 1013, 271, 1);
			Helper.Delay(2);
			Helper.Click(device, 726, 241);
			Helper.Click(device, 855, 588);
			KAutoHelper.ADBHelper.Swipe(device, 618, 187, 1046, 166, 500);
			Helper.Delay(2);
			Helper.ClickOutPoint(device);
			Helper.ClickOutPoint(device);

		}
		internal static void LV11toLV15(string device)
		{
			Helper.IsMainPage(device);
			ClickNV(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			//lv12
			DongYXanh(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 196, 553);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 384, 564);
			DongYDo(device);
			DiDen(device);
			//LV13
			DongYXanh(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 575, 559);
			DongDo(device);
			BoQuaTron(device);
			ClickMiddle(device);
			BoQua(device);
			Helper.Delay(5);
			ClickMiddle(device);
			BoQua(device);
			BoQua(device);

			Helper.FindAndClick(device, Helper.BitmapFile("doiHinh"));
			Helper.Click(device, 126, 508);
			Helper.Click(device, 992, 637);
			Helper.Delay(2);

			ClickLeft(device, 2);

			Helper.Delay(2);

			Helper.ClickOutPoint(device);
			Helper.Delay(1);
			Helper.ClickOutPoint(device);

			ClickNV(device);
			DiDen(device);
			PhoBanNV(device, 578, 553);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 753, 559);
			DongYDo(device);
			DiDen(device);
			//LV14
			DongYXanh(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 839, 559);
			DongYDo(device);
			DiDen(device);
			//LV15
			DongYXanh(device);
			DongYXanh(device);
			BoQuaTron(device);
			BoQua(device);
			ClickLeft(device, 20);
			BoQua(device);
			BoQuaTron(device);
		}
		internal static void LV15toLV20(string device)
		{
			ClickNV(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			//LV16
			DongYXanh(device);
			DongYXanh(device);
			BoQuaTron(device);
			ClickMiddle(device);
			BoQua(device);
			ClickNV(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			//LV17
			DongYXanh(device);
			DongYXanh(device);
			BoQua(device);
			ClickNV(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 831, 559);
			KetThucDo(device);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			//LV18
			DongYXanh(device);
			DongYXanh(device);
			ClickLeft(device, 2);
			Helper.Delay(2);
			ClickNV(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			//LV19
			DongYXanh(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			KAutoHelper.ADBHelper.Tap(device, 640, 292, 50);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 839, 548);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 839, 548);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			Helper.Click(device, 268, 287);
			Helper.Click(device, 822, 631);
			Helper.Click(device, 753, 506);
			DongYXanh(device);
			Helper.Click(device, (int)Helper.exitPtn.X, (int)Helper.exitPtn.Y);
			DiDen(device);
			//LV20
			DongYXanh(device);
			DongYXanh(device);
			ClickLeft(device, 5);
			BoQua(device);
			ClickLeft(device, 10);
		}
		internal static void LV20toLV24(string device)
		{
			Helper.IsMainPage(device);
			ClickNV(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 903, 564);
			DongYDo(device);
			PhoBanNV(device, 1102, 564);
			DongYDo(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			//LV21
			DongYXanh(device);
			DongYXanh(device);
			BoQua(device);
			ClickNV(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			DiDen(device);
			Helper.Click(device, 586, 610);
			bool statut = false;
			while (!statut)
			{
				if (Helper.IsPresent(device, Helper.BitmapFile("chon")))
				{
					var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
					var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Helper.BitmapFile("chon"), 0.8);
					if (point != null)
					{
						KAutoHelper.ADBHelper.Tap(device, point.Value.X, point.Value.Y);
						Helper.Delay(2);
					}
					statut = true;
				}
			}
			Helper.Click(device, (int)Helper.exitPtn.X, (int)Helper.exitPtn.Y);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 193, 545);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			//LV22
			DongYXanh(device);
			DongYXanh(device);
			BoQua(device);
			ClickNV(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			Helper.Click(device, 960, 480);
			Helper.Click(device, (int)Helper.exitPtn.X, (int)Helper.exitPtn.Y);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			//LV23
			DongYXanh(device);
			DongYXanh(device);
			BoQua(device);
			BoQua(device);
			ClickNV(device);
			DiDen(device);
			ChonNPC(device);
			Helper.Click(device, (int)Helper.exitPtn.X, (int)Helper.exitPtn.Y);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 384, 556);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 568, 551);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			//LV24
			DongYXanh(device);
			DongYXanh(device);
			ClickLeft(device, 2);
			Helper.Delay(2);
		}
		internal static void LV24toLV27(string device)
		{
			ClickNV(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 769, 548);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			//LV25
			DongYXanh(device);
			DongYXanh(device);
			BoQuaTron(device);
			ClickMiddle(device);
			BoQua(device);
			ClickNV(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			Helper.Click(device, 524, 333);
			Helper.Click(device, 954, 486);
			BoQuaTron(device);
			ClickMiddle(device);
			Helper.Click(device, 1124, 365);
			KAutoHelper.ADBHelper.Swipe(device, 841, 228, 314, 300);
			Helper.Click(device, 1124, 429);
			KAutoHelper.ADBHelper.Swipe(device, 841, 228, 314, 300);
			Helper.Click(device, 535, 583);
			Helper.Delay(10);
			ClickMiddle(device);
			ClickMiddle(device);
			ClickLeft(device, 20);
			BoQua(device);
			ClickNV(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			Helper.Click(device, 255, 540);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 769, 548);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			//LV26
			DongYXanh(device);
			DongYXanh(device);
			Helper.ClickOutPoint(device);
			Helper.FindAndClick(device, Helper.BitmapFile("doiHinh"));
			Helper.Click(device, 112, 263);
			Helper.Click(device, 623, 634);
			Helper.Click(device, 992, 637);
			Helper.Delay(2);
			ClickLeft(device, 2);

			Helper.Click(device, 518, 330);
			Helper.Click(device, 623, 634);
			Helper.Click(device, 992, 637);
			Helper.Delay(2);
			ClickLeft(device, 2);

			Helper.ClickOutPoint(device);
			Helper.ClickOutPoint(device);

			ClickNV(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 833, 548);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			//LV27
			DongYXanh(device);
			DongYXanh(device);
			BoQua(device);
		}
		internal static void LV27toLV30(string device)
		{
			ClickNV(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 833, 548);
			DongYDo(device);
			PhoBanNV(device, 833, 548);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			//LV28
			DongYXanh(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 895, 548);
			DongYDo(device);
			DiDen(device);
			//LV29
			DongYXanh(device);
			DongYXanh(device);
			BoQuaTron(device);
			ClickMiddle(device);
			BoQua(device);
			ClickNV(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 1102, 548);
			DongDo(device);
			BoQuaTron(device);
			ClickMiddle(device);
			BoQua(device);
			BoQua(device);
			Helper.FindAndClick(device, Helper.BitmapFile("doiHinh"));
			Helper.Click(device, 112, 263);
			Helper.Click(device, 623, 634);
			Helper.Click(device, 992, 637);
			Helper.Delay(2);

			ClickLeft(device, 2);

			Helper.Click(device, 518, 330);
			Helper.Click(device, 623, 634);
			Helper.Click(device, 992, 637);
			Helper.Delay(2);
			ClickLeft(device, 2);

			Helper.ClickOutPoint(device);
			Helper.Delay(1);
			Helper.ClickOutPoint(device);
			ClickNV(device);
			DiDen(device);
			PhoBanNV(device, 1102, 548);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 193, 548);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DongYXanh(device);
			Helper.ClickOutPoint(device);
		}
		internal static void CustomLV(string device)
		{
			BoQua(device);
			ClickNV(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			//LV17
			DongYXanh(device);
			DongYXanh(device);
			BoQua(device);
			ClickNV(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 831, 559);
			KetThucDo(device);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			//LV18
			DongYXanh(device);
			DongYXanh(device);
			ClickLeft(device, 2);
			Helper.Delay(2);
			ClickNV(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			//LV19
			DongYXanh(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			KAutoHelper.ADBHelper.Tap(device, 640, 292, 50);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 839, 548);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 839, 548);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			Helper.Click(device, 268, 287);
			Helper.Click(device, 822, 631);
			DongYXanh(device);
			Helper.Click(device, (int)Helper.exitPtn.X, (int)Helper.exitPtn.Y);
			DiDen(device);
			//LV20
			DongYXanh(device);
			DongYXanh(device);
			ClickLeft(device, 5);
			BoQua(device);
			ClickLeft(device, 10);
		}
		internal static void CustomLV2(string device)
		{
			DongYXanh(device);
			BoQuaTron(device);
			ClickMiddle(device);
			KetThucDo(device);
			DongYDo(device);
			ClickMiddle(device);
			ClickMiddle(device);
			ClickMiddle(device);
			ClickMiddle(device);
			BoQua(device);
			BoQua(device);
			BoQua(device);
			BoQuaTron(device);
			ClickMiddle(device);
			ClickMiddle(device);
			BoQua(device);
			//LV6
			DongYXanh(device);
			BoQuaTron(device);
			ClickMiddle(device);
			//LV7
			DongYXanh(device);
			BoQua(device);
			//LV8
			DongYXanh(device);
			KAutoHelper.ADBHelper.Tap(device, 120, 553, 30);
			ClickMiddle(device);
			ClickMiddle(device);
			//LV11
			DongYXanh(device);
			BoQua(device);
			ClickMiddle(device);
			Helper.IsMainPage(device);

			Helper.FindAndClick(device, Helper.BitmapFile("doiHinh"));
			Helper.Click(device, 473, 53);
			Helper.Click(device, 1067, 542);
			KAutoHelper.ADBHelper.Tap(device, 1013, 271, 1);
			Helper.Delay(2);
			KAutoHelper.ADBHelper.Tap(device, 1013, 271, 1);
			Helper.Delay(2);
			Helper.Click(device, 726, 241);
			Helper.Click(device, 855, 588);
			KAutoHelper.ADBHelper.Swipe(device, 618, 187, 1046, 166, 500);
			Helper.Delay(2);
			Helper.ClickOutPoint(device);
			Helper.ClickOutPoint(device);
		}
		internal static void CustomLV3(string device)
		{
			DiDen(device);
			PhoBanNV(device, 384, 556);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 568, 551);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			//LV24
			DongYXanh(device);
			DongYXanh(device);
			ClickLeft(device, 2);
			Helper.Delay(2);
		}
		internal static void CustomLV4(string device)
		{
			DongYXanh(device);
			DongYXanh(device);
			BoQua(device);
			ClickNV(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			Helper.Click(device, 960, 480);
			Helper.Click(device, (int)Helper.exitPtn.X, (int)Helper.exitPtn.Y);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			//LV23
			DongYXanh(device);
			DongYXanh(device);
			BoQua(device);
			BoQua(device);
			ClickNV(device);
			DiDen(device);
			ChonNPC(device);
			Helper.Click(device, (int)Helper.exitPtn.X, (int)Helper.exitPtn.Y);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 384, 556);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			PhoBanNV(device, 568, 551);
			DongYDo(device);
			DiDen(device);
			DongYXanh(device);
			DiDen(device);
			ChonNPC(device);
			BoQuaTron(device);
			ClickMiddle(device);
			DiDen(device);
			//LV24
			DongYXanh(device);
			DongYXanh(device);
			ClickLeft(device, 2);
			Helper.Delay(2);
		}
		internal static void ChonCungDong(string device)
		{
			if(Helper.FindAndClick(device, Helper.BitmapFile("bang")))
			{
				Helper.Click(device, 293, 542);
				DongYXanh(device);
				Helper.Delay(5);
				Helper.ClickOutPoint(device);
			}
		}
		internal static void NhanVangPB(string device)
		{
			Helper.IsMainPage(device);

			while (!Helper.IsPresent(device, Helper.BitmapFile("phoBan")))
			{
				KAutoHelper.ADBHelper.Swipe(device, 500, 505, 938, 505);
				Helper.Delay(2);
			}

			if (Helper.IsPresent(device, Helper.BitmapFile("phoBan")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("phoBan"));

				Helper.Click(device, 395, 524);

				Helper.Click(device, 163, 569);
				Helper.Click(device, 960, 370);
				Helper.Click(device, 626, 473);
				Helper.Click(device, 1040, 368);
				Helper.Click(device, 626, 473);
				Helper.ReturnToMainpage(device, 1);

				Helper.Click(device, 406, 569);
				Helper.Click(device, 960, 370);
				Helper.Click(device, 626, 473);
				Helper.Click(device, 1040, 368);
				Helper.Click(device, 626, 473);
				Helper.ReturnToMainpage(device, 1);

				Helper.ReturnToMainpage(device, 2);
			}
		}
	}
}
