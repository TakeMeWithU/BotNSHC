   M S B A M L   `   `   `  ���� B  >BotNSHC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BotNSHCBotNSHC      BotNSHC.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:BotNSHC     V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���    ! MaterialDesignLightBackground#���  $��Medium"�$��14(�  � 
ResizeMode$  CanMinimize=� � Title$ BotNSHC��$	��780��$	��405����:  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .���  � ColumnDefinitions �� $��5 ��� $��30 ��� $��5 ��� $��30 ��� $��5 ��� $��30 ��� $��5 ��� $��30 ��� $��5 ��� $��30 ��� $��5 ��� $��30 ��� $��5 ��� $��30 ��� $��5 ��� $��30 ��� $��5 ��� $��30 ��� $��5 ��� $��30 ��� $��5 ��� $��30 ��� $��5 � � RowDefinitions �� $��5 ��� $��35 ��� $��5 ��� $��35 ��� $��5 ��� $��35 ��� $��5 ��� $��2 ��� $��5 ��� $��35 ��� $��5 ��� $��35 ��� $��5 ��� $��35 ��� $��5 ��� $��35 ��� $��5 ��� $��2 ��� $��5 ��� $��35 ��� $��5 ��� $��35 ��� $��5 ��� $��35 ��� $��5 ��� $��35 ��� $��5 ��� $��35 ��� $��5 ��� $��35 ��� $��5 ��� $��35 ��� $��5 ��� $��35 ��� $��5 ��� $��35 ��� $��5 ��� $��35 ��� $��5 ��� $��35 ��� $��5 �.+��� $��1��$��1��$��8��$��5��.+��� $��/Images/logoNSHC.png��$	��114���� $��1��$��9��$��5��.+�)  #MaterialDesignThemes.Wpf.DialogHost     CloseOnClickAway .    DialogContent �� $	��300��$
��auto��$��5q�.+��� .+��� !Thiết bị đang kết nối:�� $��5q�.+��� -    ��Name$ ListViewDevicesConnected���� .+���  # MaterialDesignFlatLightBgButton#���     CloseDialogCommand#��Z $��Close��.���� -   #���     OpenDialogCommand#��Z $��0q�$��12(�$��Thiết bị���� $��1��$��17��$��5��.+��� -   #���  $��0q�$��12(�$
��File���� $��3��$��9��$��5��.+��� -   #���  $��0q�$��12(�$
��NSHC���� $��3��$��17��$��5��.+��� -   #���  $��0q�$��12(�$��
Tắt NSHC���� $��7��$��0��$��23��
���   �&   System.Windows.Controls.DataGrid  -   	  Name$	 DataGridUsers��$��9��$��1��$��17��$��7��
   AutoGenerateColumns
 .  $
��auto��$
��Auto=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$	 N°��  MaterialDesignDataGridCell   	CellStyle# �     Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ Index�  $
 User��# �  $ *  �� $ Username�  $ Password��# �  $ *  �� $ Password�  $ Server��# �  $ *  �� $ Server��� $��9��$��19��$��3��.+�   .  �� $	��300��$
��auto��$��5q�.+��� .+��� Tài khoản bắt đầu:�� -    ��Name$ startNumber����  �� Orientation$ 
Horizontal=�$��Bottom=�$��Right=�.+��� -   $
��auto��#���  #��Z $��Valid���� $
��auto��#���  #��Z $��Close��.���� #���  $��Bắt đầu��$��0q�$��0q�#��Z �� $��11��$��19��$��3��.+�   .  �� $	��300��$
��auto��$��5q�.+��� .+��� Tài khoản kết thúc:�� -	   $ 	endNumber���� $ 
Horizontal=�$��Bottom=�$��Right=�.+��� -
   $
��auto��#���  #��Z $��Valid���� $
��auto��#���  #��Z $��Close��.���� #���  $��Kết thúc��$��0q�$��0q�#��Z �� $��13��$��19��$��3��.+�   .  �� $	��300��$
��auto��$��5q�.+��� .+��� Tài khoản :�� $��5q�$��Center=�.+��� -    ��Name$ NextUserTbl���� .+��� #���  #��Z $��Close��.���� -   #���  #��Z $��0q�$��12(�$
��Next���� $��15��$��19��$��3��.+�   .  �� $	��300��$
��auto��$��5q�.+��� .+��� Tài khoản :�� $��5q�$��Center=�.+��� -   $ BackUserTbl���� .+��� #���  #��Z $��Close��.���� -   #���  #��Z $��0q�$��12(�$
��Back���� $��17��$��0��$��23��
���   ��� $��19��$��1��$��3��.+��� -   #���  $��0q�$��12(�$��Đăng nhập���� $��19��$��5��$��3��.+��� -   #���  $��0q�$��12(�$��Đăng xuất���� $��19��$��9��$��5��.+��� -   #���  $��0q�$��12(�$
��Test���� $��19��$��15��$��3��.+��� -   #���  $��0q�$��12(�$��Pause���� $��19��$��19��$��3��.+��� -   #���  $��0q�$��12(�$��Continue���� $��21��$��1��$��3��.+�   .  �� $	��300��$
��auto��$��5q�.+��� .+��� Tên tài khoản reg:�� -   $ NameRegAccount���� $ 
Horizontal=�$��Bottom=�$��Right=�.+��� -   $
��auto��#���  #��Z $��Valid���� $
��auto��#���  #��Z $��Close��.���� #���  $��Clone 30��$��0q�$��0q�#��Z �� $��21��$��15��$��3��.+��� -   #���  $��0q�$��12(�$��MainPage���� $��23��$��1��$��9��$��11��$
��Auto=�
�������.���� -    ��Name$ FuncsScp��.+�	� -    	�Name$ DoNotThingRbt��$��4q� d� 	IsChecked$
 TrueY�$��Không làm gì��	� -   $��4q�$ FalseY�$��Vô bang��	� -   $��4q�$ FalseY�$��
Rời bang��	� -   $��4q�$ FalseY�$��GopMax��	� -   $��4q�$ FalseY�$��Mua bông vui vẻ��	� -   $��4q�$ FalseY�$��Tặng bông vui vẻ���� -   $ funcSelectedLtv��$��23��$��11��$��9��$��9��
�������$
��Auto=�
���   �$��1q��� $��23��$��21��$��9��$ Vertical=�$��Center=�.+�   .  �� $	��300��$
��auto��$��5q�.+��� .+��� Chức năng:�� -   $ listFuncLtv��$	��200��$
��Auto=��� $ 
Horizontal=�$��Bottom=�$��Right=�.+��� -    $
��auto��#���  #��Z $��Valid���� $
��auto��#���  #��Z $��Close��.����   MaterialDesignToolButton#���  #��Z $
��Left=�$��30��.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Plus=��� -!   #���  .��  $ ArrowUpDropCircle=��� -"   #���  .��  $ ChevronDownCircle=��� -#   #���  .��  $ DeleteForeverOutline=�$��32���� $��33��$��11��$��3��.+��� -$   $��OneShot��$��0q��� $��33��$��15��$��3��.+��� -%   $��Start��$��0q��� $��33��$��19��$��3��.+��� -&   $��0q�$��12(�$
��Auto���� -'   $��Scroller��$��35��$��1��$��5��$��21��$
��Auto=�.���� -(   $ TextBlockOutput��$��Stretch=�$��Stretch=�
������
���   �$��14(�$	��100��$
��Wrap=�����  �� ElementName$ Scroller��$ ViewportWidth�