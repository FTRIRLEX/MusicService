   M S B A M L   `   `   `  ����M  ICourseProject v1.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CourseProject_v1._1.HelpersCourseProject_v1._1.Helpers  5      O,clr-namespace:CourseProject_v1._1.ViewModelsCourseProject_v1._1.ViewModels  5      U/clr-namespace:CourseProject_v1._1.Views.Windows!CourseProject_v1._1.Views.Windows  5	      2    ,CourseProject_v1._1.Views.Windows.TracksPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      7convert)clr-namespace:CourseProject_v1._1.Helpers  5      5vm,clr-namespace:CourseProject_v1._1.ViewModels  5      ;local/clr-namespace:CourseProject_v1._1.Views.Windows  5	        � 	Resources  5      8  2CourseProject_v1._1.Helpers.TrackToSingerConvertor   TrackToSinger7  1CourseProject_v1._1.Helpers.TrackToImageConverter  TrackToImage��%:   &	        &	        5   
   6)     5   
   6(   5      .��5      � ���	#ffdadada.+�5   
   �� $��Tracks��6   $
��Bold"�6"   $��30(�64   $��20q�6B   $��45��6N   $
��Left=�6Z   $	��Top=�6u   �� 5   
   $	��Top=�6   $��Right=�6-    �� Orientation$ 
Horizontal=�6I   $��	0 20 50 0q�6b   .+�5      �� $��45��6:   $��45��6E   $��30 0 0 0q�6Q   ��6   �� *LikeTrackCommand+.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Heart=�6*   $
��auto��67   $
��auto��6D   $��Center=�6R   5      �� 5      $��45��6<   $��45��6G   $��30 0 0 0q�6S   ��6   �� *UnlikeTrackCommand+.��5        $ HeartOff=�6*   $
��auto��6:   $
��auto��6G   $��Center=�6U   5      5      �� 5   
   -   5        $��Visible=�5      $��0,83,0,0q�6Q   .��5      �� $	��468��6   $	��705��6�   ��6#   �� *	TrackList+ �� SelectedValue 6E   �� *selectedValue+ �� SelectedItem 6m   �� *main.selectedTrack+��5      �� 5      .R�5      �� $ 
Horizontal=�6%   .+�5      �� $��50��6i   $��50��6t   ��6$   �� *
album_id+ �� 	Converter# [ 6t   �� 5       $	��200��6D   $��	20 0 20 0q�6P   $��Center=�6c   ��6(   �� *
track_name+6c   �� 5!      $	��200��6k   $��	20 0 20 0q�6w   $��Center=�6�   ��6(   �� *
album_id+# [  6�   5"      5#      5%      5&      5'      5(      