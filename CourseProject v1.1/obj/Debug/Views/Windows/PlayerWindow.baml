   M S B A M L   `   `   `  ����M  ICourseProject v1.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CourseProject_v1._1.HelpersCourseProject_v1._1.Helpers  5   	   U/clr-namespace:CourseProject_v1._1.Views.Windows!CourseProject_v1._1.Views.Windows  5   	   O,clr-namespace:CourseProject_v1._1.ViewModelsCourseProject_v1._1.ViewModels  5	   	   4    .CourseProject_v1._1.Views.Windows.PlayerWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =convert)clr-namespace:CourseProject_v1._1.Helpers     5   	   Alocal/clr-namespace:CourseProject_v1._1.Views.Windows     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   5vm,clr-namespace:CourseProject_v1._1.ViewModels  5	   	     � Title$  PlayerWindow��5   	   $	��700��6   $	��900��6+    � 	Resources 5      8  2CourseProject_v1._1.Helpers.TrackToSingerConvertor   TrackToSinger��%   &	          5   
   6)   5      .��5      )  #MaterialDesignThemes.Wpf.DialogHost     IsOpen 5   	   �� *DialogVisible+   DialogContent 5   
   �� 5      $
��Auto��6   $
��Auto��6#   ���	#ffdadada._�5      �� $��16q�6   ���	#FFdadada.+�5      �� ��6    �� *
DialogText+�� 5      $��0 10 0 0q�6   $��Close��6/   $��90��6?   $��30��6J   ��6V   �� *CloseDialogCommand+5      5      .��5   
   �  � RowDefinitions 5      �� 5      $	��550 �6    �� 5      $	��150 �6     � ColumnDefinitions 5      �� 5      $	��190 �6#   �� 5       $	��710 �6#   .+�5"      ��  �� SelectedIndex 6   �� *SelectedMenuItem+.@�5#      �� $��60��6   .��5$      ��  �� Orientation$ 
Horizontal=�6!   .+�5%      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Music=�62   $��30��6?   $��30��6J   $��Center=�6V   $��5q�6q   �� 5&      $��
All Tracks��6$   $��20(�66   $
��Bold"�6D   $��Center=�6V   5'      5(      �� 5)      $��60��6   .��5*      �� $ 
Horizontal=�6!   .+�5+        $ Heart=�62   $��30��6?   $��30��6J   $��Center=�6V   $��5q�6q   �� 5,      $��My Music��6$   $��20(�64   $
��Bold"�6B   $��Center=�6T   5-      5.      �� 5/      $��60��6   .��50      �� $ 
Horizontal=�6!   .+�51        $ PlaylistMusic=�62   $��30��6G   $��30��6R   $��Center=�6^   $��5q�6y   �� 52      $��	Playlists��6$   $��20(�65   $
��Bold"�6C   $��Center=�6U   53      54      �� 55      $��60��6   .��56      �� $ 
Horizontal=�6!   .+�57        $ Album=�62   $��30��6?   $��30��6J   $��Center=�6V   $��5q�6q   �� 58      $��Albums��6$   $��20(�62   $
��Bold"�6@   $��Center=�6R   59      5:      �� 5;      $��60��6   .��5<      �� $ 
Horizontal=�6!   .+�5=        $ Account=�62   $��30��6B   $��30��6M   $��Center=�6Y   $��5q�6t   �� 5>      $��20(�6A   $
��Bold"�6O   $��Center=�6a   ��6$   �� *AccountName+6a   5?      5@      �� 5A      $��60��6   .��5B      �� $ 
Horizontal=�6!   .+�5C        $ 	ExitToApp=�62   $��30��6C   $��30��6N   $��Center=�6Z   $��5q�6u   �� 5D      $
��Exit��6$   $��20(�60   $
��Bold"�6>   $��Center=�6P   5E      5F      �� 5G      $��60��6   y�6,   �� *AdminVisibility+.��5H      �� $ 
Horizontal=�6!   .+�5I        $ Account=�62   $��30��6B   $��30��6M   $��Center=�6Y   $��5q�6t   �� 5J      $��
Admin Page��6$   $��20(�66   $
��Bold"�6D   $��Center=�6V   5K      5L      5M      �� 5N      -   5        	 ��Name$	 ContentPage��5N   :   $��1��6   $��0��6-   ��6O   �� *
selectedVM+5O      �� 5P      $��1��6   $��1��6&   $��	0,0,10,31q�66   $ 
Horizontal=�6I   .+�5Q      �� $��20(�6F   $��	20 0 20 0q�6T   $��Center=�6g   $	��150��6�   $
��Left=�6�   ��6   �� *selectedTrack.track_name+6�   �� 5R      $��0 0 20 0q�6m   $��20(�6   $	��150��6�   $��Center=�6�   ��6   �� *selectedTrack.album_id+
 �� 	Converter#
 [  6�   �� 5S      $��30��6>   $��30��6I   $��0q�6U   ��6   �� *PlayTrackCommand+.��5T        $��25��6J   $��25��6U   $��Center=�6a    6.   �� *
ButtonPlay+6a   5U      �� 5V      -   5         ��Name$ Volume��5V      $��30 0 0 0q�6)   $	��100��6;   $��Center=�6G    � Maximum$ 1Q�6b    � Minimum$ 0Q�6n    � Value 6z   �� *MediaPlayer.Volume+5W      5Y      5Z      5[      