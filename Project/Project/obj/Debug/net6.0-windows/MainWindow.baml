   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjectProject  5   	   7 clr-namespace:Project.ViewModelsProject.ViewModels  5   	   ;"clr-namespace:Project.UserControlsProject.UserControls  5	   	       Project.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Project     5   	   /vm clr-namespace:Project.ViewModels     5   	   1uc"clr-namespace:Project.UserControls     5	   	     � Title$  
MainWindow��5   	   $	��650��6   $
��1500��6)    � WindowStartupLocation$ CenterScreen=�66    � DataContext 5      %   Project.ViewModels.NavigationVM  5   
    � 	Resources 5       �� DataType"   Project.ViewModels.ProductVM$   Project.UserControls.ProductUC    Project.ViewModels.OrderVM"   Project.UserControls.OrderUC!   Project.ViewModels.ReportVM#   Project.UserControls.ReportUC$   Project.ViewModels.WarehouseVM&	    Project.UserControls.WarehouseUC#
   Project.ViewModels.CustomerVM%   Project.UserControls.CustomerUC!   Project.ViewModels.MemberVM#   Project.UserControls.MemberUC��%�  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5      *,
 +)(�� �     5      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5      	  5      �� 5   
   " 
 6   .R�5        5      �� 5   
   "  6   .R�5         5!      5"      .��5#      �  � ColumnDefinitions 5$   
   �� 5%      $
��auto �6   �� 5&      $��7* �6   .+�5)   
   � $��0��6    � RowDefinitions 5*      �� 5+      $
��auto �6    �� 5,      $
��auto �6    �� 5-      $��* �6    .+�5/      ]� $
��0 10q�6   .+�50      �� $	��Top=�6    *  &MaterialDesignFloatingActionDarkButton#��[  52       � ToolTip$- 'MaterialDesignFloatingActionLightButton��53      {�51      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+	 �� AncestorType
	 Window.��54      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 Account=�6.   $��30��6=   $��30��6H   55      �� 56      $	��Top=�6   $��Center=�61   $��10q�6N   $
��Bold"�6Z   $��Center=�6l   $��14(�6�   	Xin chào6�   57      ]� 58      $��1��6   $��Center=�6%   .+�59      �� $
��0 10q�6   $	��Top=�5:      $
��Left=�5;         MaterialDesignFlatDarkButton#��[ 5>      $
 Home��5?      ��5<      �� *WarehouseCommand+{�5=      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
	 Window.��5@      ��  �� Orientation$ 
Horizontal=�6!   .+�5A        $
 	Warehouse=�62   �� 5B      $	��5 0q�6$   $��	Kho hàng��61   5C      5D      �� 5E      $
��0 10q�6   $	��Top=�5F      $
��Left=�5H      #��[ 5J      $ Report��5K      ��5G      �� *CustomerCommand+{�5I      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
	 Window.��5L      �� $ 
Horizontal=�6!   .+�5M        $
 AccountMultipleOutline=�62   �� 5N      $	��5 0q�6$   $��Khách hàng��61   5O      5P      �� 5Q      $
��0 10q�6   $	��Top=�5R      $
��Left=�5S      #��[ 5V      $
 Home��5W      ��5T      �� *ProductCommand+{�5U      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
	 Window.��5X      �� $ 
Horizontal=�6!   .+�5Y        $
 PackageVariantClosed=�62   �� 5Z      $	��5 0q�6$   $��Sản phẩm��61   5[      5\      �� 5]      $
��0 10q�6   $	��Top=�5^      $
��Left=�5_      #��[ 5b      $
 Cart��5c      ��5`      �� *OrderCommand+{�5a      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
	 Window.��5d      �� $ 
Horizontal=�6!   .+�5e        $

 Cart=�62   �� 5f      $	��5 0q�6$   $��Đơn hàng��61   5g      5h      �� 5i      -   5        $��	btnReport��5j      $
��0 10q�5i      $	��Top=�5k      $
��Left=�5m      #��[ 5o      $ Report��5p      ��5l      �� *ReportCommand+{�5n      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
	 Window.��5q      �� $ 
Horizontal=�6!   .+�5r        $
 ChartBoxOutline=�62   �� 5s      $	��5 0q�6$   $��Thống kê��61   5t      5u      �� 5v      -   5        $��
btnAccount��5w      $
��0 10q�5v      $	��Top=�5x      $
��Left=�5z      #��[ 5|      $ Report��5}      ��5y      �� *MemberCommand+{�5{      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
	 Window.��5~      �� $ 
Horizontal=�6!   .+�5        $
 AccountGroup=�62   �� 5�      $	��5 0q�6$   $��Tài khoản��61   5�      5�      5�      ]� 5�      $��2��6   5�      5�      �� 5�   
   $��1��6   ��6)   �� *CurrentView+5�      5�      