   M S B A M L   `   `   `  ����M  ICourseProject v1.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CourseProject_v1._1.HelpersCourseProject_v1._1.Helpers  5      U/clr-namespace:CourseProject_v1._1.Views.Windows!CourseProject_v1._1.Views.Windows  5      2    ,CourseProject_v1._1.Views.Windows.AlbumsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      7convert)clr-namespace:CourseProject_v1._1.Helpers  5      ;local/clr-namespace:CourseProject_v1._1.Views.Windows  5        � 	Resources  5      8  2CourseProject_v1._1.Helpers.TrackToSingerConvertor   TrackToSinger7  1CourseProject_v1._1.Helpers.TrackToImageConverter  TrackToImage��%:   &	        &	        5   
   6)     5   
   6(   5      .��5      )  #MaterialDesignThemes.Wpf.DialogHost     IsOpen 5      �� *DialogVisible+   DialogContent 5   
   �� 5      $	��270��6   $	��400��6"   
�������._�5      �� $��16q�6   
�������.+�5      �� -   5         ��Name$ 	AlbumName��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Album Name��6p    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��61   �� *	AlbumName+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      $
��0 10q�6e   ��6   �� *genres+ �� SelectedItem 6>   �� *selectedGenre+6e   �� 5      $��Add File��6   $
��0 10q�6W   ��60   �� *ChooseCoverCommand+6W   �� 5      $��Create album��6   $
��0 10q�6[   ��64   �� *CreateAlbumCommand+6[   �� 5      $��Close��6   $
��0 10q�6Y   ��6-   �� *CloseCreateAlbumCommand+6Y   5      5      .��5   
   � ���	#ffdadada.+�5   
   �� $��Albums��6   $
��Bold"�6"   $��30(�64   $��	20,20,0,0q�6B   $��45��6U   $
��Left=�6a   $	��Top=�6|   �� 5      $��Create��6   $��1��6Q   $��	0 20 50 0q�6a   $	��Top=�6t   $��Right=�6�   $	��110��6�   ��6&   �� *OpenCreateAlbumCommand+6�   �� 5       $��
Edit Album��6   $��15(�6O   $��Right=�6]   $	��Top=�6y   $��	0 75 50 0q�6�   $	��110��6�   ��6*   �� *EditAlbumCommand+6�   �� 5!      $��
Open Album��6   $��15(�6O   $��Right=�6]   $	��Top=�6y   $��
0 75 180 0q�6�   $	��120��6�   ��6*   �� *OpenAlbumCommand+6�   �� 5"      -   5        $��Visible=�5"      $��	0,132,0,0q�6U   $��0��6h   .��5#      �� $	��418��6   $	��705��6l   ��6#   �� *	AlbumList+ 6E   �� *selectedAlbum+��5$      �� 5%      .R�5&      ��  �� Orientation$ 
Horizontal=�6%   .+�5'   "   �� $��50��6m   $��50��6x   ��6(   �� *
album_id+ �� 	Converter# [ 6x   �� 5(   "   $��50 0 0 0q�6I   $	��200��6[   $��Center=�6g   ��6,   �� *albums_name+6g   �� 5)      $��	20 0 20 0q�6k   $	��200��6~   $��Center=�6�   ��6(   �� *
album_id+# [  6�   5*      5+      5-      5.      5/      50      51      