   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   B >CREATOR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CREATOR.EntitiesCREATOR.Entities 5   	      CREATOR.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   8CreateContentclr-namespace:CREATOR.Entities     5   	     � Title$  CREATOR��5   	   $	��500��6   $	��300��6&   $��18(�62   $	��250��6@   $	��300��6O   $��0q�5      (   "MahApps.Metro.Controls.MetroWindow   	GlowBrush
 �   � � 
ResizeMode$ CanResizeWithGrip=�6=      WindowTransitionsEnabled .   � WindowStartupLocation$ CenterScreen=�5   8   .��5	      �  � RowDefinitions 5
   
   �� 5      $��42 �6   6*   �� 5      $��42 �6   6*   �� 5      6   �� 5      $��45 �6   6*    � ColumnDefinitions 5   
   �� 5      $��2* �6   6,   �� 5      $��1* �6   6,   .+�5   
   �� -   5        $��txtPath��5      $��0��6D   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Path to folder��5      $��5q�6E   $��Center=�5      $��14(�64   ��5   !   �� *Path+ �� Mode$ TwoWay=�5   4   �� 5   
   -   5        $��0��5      $��1��6   $��5q�6.   $��Browse��6T   $��14(�5      $��Center=�6      CustomGreenButton#��[  5      5      �� 5   
   -   5        $��txtFolderName��5   D   $��0��5      $��14(�6"   $��2��60   $��1��6E   $��5q�6R   $ Name to folder��5      $��Center=�5      ��5      �� *
FolderName+60   �� 5    
   $��Folders��6   $��2��6$   $��2��61   $��5q�6E   .��5!      R� -   5        $��treeViewFolders��5!      	 � 	Resources	 5"      
 �� DataType  CREATOR.Entities.Folder �� ItemsSource  CREATOR.Entities.File d� 	IsChecked��%  (��       5#   /   *, +)(�� l     5&   #   *, +)�� 5#      "
  6/    6X   �� *Files+.R�5$      �� ��6    �� *
FolderName+6A   5%      �� 5&      "
  6#   .R�5'      �� ��6#   �� *
FileName+ 6@   �� *
IsSelected+$ TwoWay=�6p   5(      5)      5*      5+      �� 5,   
   -   5        $��3��5,      $��2��6   $��5q�62   #��[  6=   $��Create��5-   .   $��14(�5.      $��Center=�6   6C   5/      50      