   M S B A M L   `   `   `  ����M  ICourseProject v1.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:CourseProject_v1._1.Views.Windows!CourseProject_v1._1.Views.Windows  5      5    /CourseProject_v1._1.Views.Windows.EditAlbumPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ;local/clr-namespace:CourseProject_v1._1.Views.Windows  5      .��5
      )  #MaterialDesignThemes.Wpf.DialogHost      IsOpen  5      �� *DialogVisible+   DialogContent 5   
   �� 5      $	��200��6   $	��400��6"   
�������._�5      �� $��16q�6   
�������.+�5      �� -   5         ��Name$ 	TrackName��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Track Name��6p    %  !MaterialDesignFloatingHintTextBox#��[  6�   ��61   �� *	TrackName+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      $��Add File��6   $
��0 10q�6V   ��60   �� *SelectFileCommand+6V   �� 5      $��Create Track��6   $
��0 10q�64   ��6B   �� *CreateTrackCommand+5      5      .��5   
   � ���	#ffdadada.+�5      �� $��
Edit Album��6   $	��Top=�6*   $
��Left=�6B   $
��Bold"�6]   $��30(�6o   $��	20,20,0,0q�6}   �� 5      $��	Add Traks��6   $	��Top=�6)   $��Right=�6A   $��	0 20 50 0q�6]   ��6p   �� *OpenAddTrackCommand+�� 5      $
��Bold"�6;   $��30(�6M   $��20 60q�6[   ��6   �� *album.albums_name+6[   �� 5      $��Tracks in this Album:��6   $��30(�65   $
��Bold"�6C   $��20 100q�6U   �� 5      -   5        $��Visible=�5      $��	0,143,0,0q�6U   .��5      �� $	��468��6   $	��705��6F   ��6'   �� *tracks+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6)   .+�5   "   �� $��	20 0 20 0q�6H   $	��150��6[   ��6,   �� *
track_name+6[   5       5!      5#      5$      5%      5'      5(      