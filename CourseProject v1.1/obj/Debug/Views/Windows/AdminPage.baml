   M S B A M L   `   `   `  ����M  ICourseProject v1.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:CourseProject_v1._1.Views.Windows!CourseProject_v1._1.Views.Windows  5      O,clr-namespace:CourseProject_v1._1.ViewModelsCourseProject_v1._1.ViewModels  5      I)clr-namespace:CourseProject_v1._1.HelpersCourseProject_v1._1.Helpers  5      1    +CourseProject_v1._1.Views.Windows.AdminPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:CourseProject_v1._1.Views.Windows     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      5vm,clr-namespace:CourseProject_v1._1.ViewModels  5      7convert)clr-namespace:CourseProject_v1._1.Helpers  5        � 	Resources  5      2  ,CourseProject_v1._1.Helpers.UserRoleToString   ToString��%   &	          5   
   6#   5      .��5      )  #MaterialDesignThemes.Wpf.DialogHost     IsOpen 5   	   �� *DialogVisibility+   DialogContent 5   
   �� 5      $	��200��6   $	��350��6"   
�������._�5      �� $��16q�6   
�������.+�5      �� $
��0 10q�6D    �� SelectedIndex 6   �� *
selectRole+.@�5      ��  �� 
IsSelected . .��5      �� $
��User��6(   5      �� 5      .��5      �� $��Singer��6(   5      �� 5      .��5      �� $��Admin��6(   5       5!      �� 5"      $��Change Role��6   $
��0 10q�6Y   ��63   �� *ChangeRoleCommand+6Y   �� 5#      $��Close��6   $
��0 10q�6T   ��6-   �� *CloseDialogCommand+6T   5$      5%      .��5'   
   � ���	#ffdadada.+�5(   
   �� $��Administration��6   $
��Bold"�6*   $��30(�6<   $��	20,20,0,0q�6J   $��45��6]   $
��Left=�6i   $	��Top=�6�   �� 5)   
   $	��150��6b   $��30��6n   $	��Top=�6z   $
��Left=�6�   $��	50 70 0 0q�6�   
���������6   �� *searchString+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   �� 5*   
   $��30��63   $��30��6>   $
��Left=�6J   $	��Top=�6e   $��
200 70 0 0q�6}   $��0q�6�   ��6   �� *SearchCommand+.��5+      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�6&   $��20��64   $��20��6?   $��Center=�6K   5,      �� 5-   
   $��Delete Account��6   $	��140��6S   $	��Top=�6_   $��Right=�6w   $��	0 20 50 0q�6�   ��6*   �� *AccountDeleteCommand+6�   �� 5.      $��Change Role��6   $	��140��6Q   $	��Top=�6]   $��Right=�6u   $��	0 70 50 0q�6�   ��6+   �� *OpenDialogCommand+6�   �� 5/      -   5        $��Visible=�5/      $��	0,132,0,0q�6U   $��0��6h   .��50      �� $	��418��6   $	��705��6q   ��6#   �� *AccountsList+ �� SelectedItem 6H   �� *selectedAccount+��51      �� 52      .R�53      �� 	 �� Orientation$	 
Horizontal=�6%   .+�54      �� $��50 0 0 0q�6G   $	��200��6Y   $��Center=�6e   ��6(   �� *user_nickname+6e   �� 55      $��	20 0 20 0q�6D   $	��200��6W   $��Center=�6c   ��6(   �� *
user_login+6c   �� 56      $��	20 0 20 0q�6h   $	��200��6{   $��Center=�6�   ��6(   �� *	user_role+
 �� 	Converter#
 [  6�   57      58      5:      5;      5<      5=      5>      