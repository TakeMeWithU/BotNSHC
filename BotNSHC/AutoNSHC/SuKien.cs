using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BotNSHC.AutoNSHC
{
	class SuKien
	{
		internal static void PhoBan(string device)
		{
			Helper.IsMainPage(device);

			while (!Helper.IsPresent(device, Helper.BitmapFile("phoBan")))
			{
				KAutoHelper.ADBHelper.Swipe(device, 500, 505, 938, 505);
				Helper.Delay(2);
			}

			if (Helper.FindAndClick(device, Helper.BitmapFile("phoBan")))
			{
				Helper.Click(device, 395, 521);

				for (int i = 0; i < 10; i += 1)
				{
					if (MainWindow.isStop)
						return;
					KAutoHelper.ADBHelper.Swipe(device, 136, 365, 336, 365);
				}
				Helper.Delay(2);

				Helper.Click(device, 166, 567);
				Helper.Click(device, 895, 559);
				Helper.Click(device, 704, 540);
				Helper.Click(device, 817, 370);
				Helper.Click(device, 763, 478);

				bool statut = false;
				while (!statut)
				{
					if(Helper.IsPresent(device, Helper.BitmapFile("quayLaiDo")) || Helper.IsPresent(device, Helper.BitmapFile("dongYXanh")))
					{
						if(Helper.IsPresent(device, Helper.BitmapFile("quayLaiDo")))
						{
							Helper.Click(device, 648, 642);
							statut = true;
						}else if(Helper.IsPresent(device, Helper.BitmapFile("dongYXanh")))
						{
							Helper.Delay(15);
							Helper.FindAndClick(device, Helper.BitmapFile("boQua"));
						}
					}else
					{
						Helper.Delay(Helper.delayTime);
					}
				}


				for (int i = 0; i < 3; i++)
				{
					Helper.Click(device, (int)Helper.exitPtn.X, (int)Helper.exitPtn.Y);
				}
			}

			Helper.IsMainPage(device);
		}
		internal static void LPLSV(string device)
		{
			Helper.IsMainPage(device);

			Helper.Click(device, 1221, 365);

			if (Helper.FindAndClick(device, Helper.BitmapFile("lplsv")))
			{
				Helper.Click(device, 645, 553);
				Helper.Delay(4);
				Helper.Click(device, 987, 279);
				Helper.Click(device, 987, 279);
				
				

				for (int i = 0; i < 20; i++)
				{
					if (MainWindow.isStop)
						return;
					KAutoHelper.ADBHelper.Tap(device, 1003, 241);
					Helper.Delay(1);
				}

				for (int i = 0; i < 2; i++)
				{
					Helper.Click(device, (int)Helper.exitPtn.X, (int)Helper.exitPtn.Y);
				}

				Helper.Click(device, 1089, 109);
			}

			Helper.IsMainPage(device);
		}
		internal static void VoteLPLSV(string device)
		{
			Helper.IsMainPage(device);

			Helper.Click(device, 1221, 365);

			if (Helper.FindAndClick(device, Helper.BitmapFile("lplsv")))
			{
				Helper.Click(device, 645, 553);
				Helper.Delay(2);
				Helper.Click(device, 669, 231);

				KAutoHelper.ADBHelper.Tap(device, 357, 320, 3);
				if (!Helper.IsPresent(device, Helper.BitmapFile("hang")))
				{
					Helper.Click(device, 532, 589);
					Helper.Delay(1);

					Helper.Click(device, 750, 487);
				}

				Helper.Click(device, 236, 46);
				Helper.Delay(2);

				Helper.Click(device, 430, 210);
				Helper.Click(device, 430, 210);

				Helper.ReturnToMainpage(device, 3);

				Helper.Click(device, 1089, 109);
			}

			Helper.IsMainPage(device);
		}
		internal static void ThuyenRong(string device)
		{
			Helper.IsMainPage(device);

			if(!Helper.IsPresent(device, Helper.BitmapFile("hoatDong")))
			{
				Helper.Click(device, 1231, 540);
			}

			if (Helper.IsPresent(device, Helper.BitmapFile("thuyenRong")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("thuyenRong"));
				Helper.Delay(2);

				while (true)
				{
					Helper.Click(device, 467, 594);
					Helper.Delay(1);
					if(!Helper.IsPresent(device, Helper.BitmapFile("dongYXanh")))
					{
						break;
					}
					Helper.Click(device, 645, 540);

					while (true)
					{
						if (Helper.IsPresent(device, Helper.BitmapFile("dongYXanh")))
						{
							Helper.FindAndClick(device, Helper.BitmapFile("dongYXanh"));
							break;
						}
					}
				}
				Helper.ReturnToMainpage(device, 1);
			}
		}
		internal static void ThanTai(string device)
		{
			Helper.IsMainPage(device);

			if (!Helper.IsPresent(device, Helper.BitmapFile("hoatDong")))
			{
				Helper.Click(device, 1231, 540);
			}

			if (Helper.IsPresent(device, Helper.BitmapFile("thanTai")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("thanTai"));

				KAutoHelper.ADBHelper.Tap(device, 607, 611);
				Helper.Delay(1);
				KAutoHelper.ADBHelper.Tap(device, 607, 611);
				Helper.Delay(1);
				KAutoHelper.ADBHelper.Tap(device, 607, 611);
				Helper.Delay(1);

				Helper.Click(device, 1100, 92);
			}
		}
		internal static void UongRuouNgamTrang(string device)
		{
			Helper.IsMainPage(device);

			if (!Helper.IsPresent(device, Helper.BitmapFile("hoatDong")))
			{
				Helper.Click(device, 1231, 540);
			}

			if (Helper.IsPresent(device, Helper.BitmapFile("uongRuouNgamTrang")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("uongRuouNgamTrang"));
				while (true)
				{
					Helper.Click(device, 481, 629);
					int i = 0;
					while (true)
					{
						if (Helper.IsPresent(device, Helper.BitmapFile("dongYXanh")))
						{
							Helper.FindAndClick(device, Helper.BitmapFile("dongYXanh"));
							break;
						}
						else
						{
							i += 1;
						}
						if (i == 10)
						{
							break;
						}
					}
					if (i == 10)
					{
						break;
					}
				}

				Helper.ClickOutPoint(device);
			}

			Helper.ReturnToMainpage(device, 1);
		}
		internal static void UocNguyenCauPhuc(string device)
		{
			Helper.IsMainPage(device);

			if (!Helper.IsPresent(device, Helper.BitmapFile("hoatDong")))
			{
				Helper.Click(device, 1231, 540);
			}

			if (Helper.IsPresent(device, Helper.BitmapFile("uocNguyenCauPhuc")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("uocNguyenCauPhuc"));
				while (true)
				{
					Helper.Click(device, 475, 602);
					int i = 0;
					while (true)
					{
						if (Helper.IsPresent(device, Helper.BitmapFile("dongYXanh")))
						{
							Helper.FindAndClick(device, Helper.BitmapFile("dongYXanh"));
							break;
						}
						else
						{
							i += 1;
						}
						if (i == 10)
						{
							break;
						}
					}
					if (i == 10)
					{
						break;
					}
				}

				Helper.ReturnToMainpage(device, 1);
			}


		}
		internal static void QuayThuong(string device)
		{
			Helper.IsMainPage(device);

			if (!Helper.IsPresent(device, Helper.BitmapFile("hoatDong")))
			{
				Helper.Click(device, 1231, 540);
			}
			List<Action> actions = new List<Action>();

			if(Helper.IsPresent(device, Helper.BitmapFile("uongRuouNgamTran")))
			{
			}
			if (Helper.IsPresent(device, Helper.BitmapFile("uongRuouNgamTran")))
			{

			}

		}
		internal static void MuaXo(string device)
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
				while (true)
				{
					if (i == 20)
					{
						break;
					}
					if (Helper.IsPresent(device, Helper.BitmapFile("Bong//" + Properties.Settings.Default.bongVV)))
					{
						Helper.Delay(2);
						var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
						var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Helper.BitmapFile("Bong//" + Properties.Settings.Default.bongVV));
						Helper.Click(device, point.Value.X + 140, point.Value.Y + 140);
						Helper.Click(device, 629, 615);
						break;
					}
					else
					{
						if (MainWindow.isStop)
							return;
						KAutoHelper.ADBHelper.Swipe(device, 634, 672, 634, 464, 900);
						Helper.Delay(2);
						i += 1;
					}
				}

			}

			Helper.IsMainPage(device);
		}
		internal static void TTTBHopAnh(string device)
		{
			Helper.IsMainPage(device);

			if (!Helper.IsPresent(device, Helper.BitmapFile("hoatDong")))
			{
				Helper.Click(device, 1231, 540);
			}

			if (Helper.IsPresent(device, Helper.BitmapFile("tuyetTrangTungBay")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("tuyetTrangTungBay"));

				Helper.Click(device, 1092, 576);
				Helper.Click(device, 1135, 42);
			}

		}
		internal static void MuaXoNuoc(string device)
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
				while (true)
				{
					if (i == 20)
					{
						break;
					}
					if (Helper.IsPresent(device, Helper.BitmapFile("thungNuoc")))
					{
						Helper.Delay(2);
						var screen = KAutoHelper.ADBHelper.ScreenShoot(device);
						var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Helper.BitmapFile("thungNuoc"));
						Helper.Click(device, point.Value.X + 140, point.Value.Y + 140);
						Helper.Click(device, 629, 615);
						break;
					}
					else
					{
						if (MainWindow.isStop)
							return;
						KAutoHelper.ADBHelper.Swipe(device, 634, 672, 634, 464, 900);
						Helper.Delay(2);
						i += 1;
					}
				}

			}

			Helper.IsMainPage(device);
		}
		internal static void MungSinhNhat(string device)
		{
			Helper.IsMainPage(device);

			if (!Helper.IsPresent(device, Helper.BitmapFile("hoatDong")))
			{
				Helper.Click(device, 1231, 540);
			}

			if (Helper.IsPresent(device, Helper.BitmapFile("mungSinhNhat")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("mungSinhNhat"));

				Helper.Click(device, 648, 519);
				Helper.Click(device, 820, 457);
				Helper.Click(device, 642, 533);


				while (Helper.TuiDay(device))
				{
					Helper.MoRongTui(device);
					Helper.Click(device, 642, 533);
				}
				int i = 0;
				while (true)
				{
					if(i == 3)
					{
						break;
					}
					if (Helper.IsPresent(device, Helper.BitmapFile("dongYXanh")))
					{
						Helper.FindAndClick(device, Helper.BitmapFile("dongYXanh"));
						break;
					}
					else
					{
						Helper.Delay(2);
						i++;
					}
				}
			}

			Helper.IsMainPage(device);
		}

		internal static void VanDo(string device)
		{
			Helper.IsMainPage(device);

			if (!Helper.IsPresent(device, Helper.BitmapFile("hoatDong")))
			{
				Helper.Click(device, 1231, 540);
			}

			if (Helper.IsPresent(device, Helper.BitmapFile("vanDo")))
			{
				Helper.FindAndClick(device, Helper.BitmapFile("vanDo"));

				Helper.Click(device, 669, 242);

				KAutoHelper.ADBHelper.Swipe(device, 634, 517, 634, 317);
				Helper.Delay(1);
				KAutoHelper.ADBHelper.Swipe(device, 634, 517, 634, 317);
				Helper.Delay(1);
				KAutoHelper.ADBHelper.Swipe(device, 634, 517, 634, 317);
				Helper.Delay(1);
				KAutoHelper.ADBHelper.Swipe(device, 634, 517, 634, 317);

				Helper.Click(device, 551, 447);
				Helper.Click(device, 640, 619);

				KAutoHelper.ADBHelper.Tap(device, 814, 412, 30);

				Helper.Click(device, 656, 522);
				Helper.Delay(1);

				Helper.Click(device, 615, 600);
				Helper.Delay(1);
				Helper.Click(device, 615, 600);
				Helper.Delay(1);
				Helper.Click(device, 656, 522);
				Helper.Delay(7);
				Helper.Click(device, 1094, 358);

				Helper.Click(device, 1108, 527);
				Helper.Click(device, 855, 474);
				Helper.Click(device, 836, 328);
				Helper.Click(device, 645, 509);
				Helper.Delay(2);
				Helper.Click(device, 629, 597);
				Helper.Click(device, 919, 43);

				Helper.ReturnToMainpage(device, 1);
			}

		}
	}
}
