   M S B A M L   `   `   `  ���� B  >Crimson, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Crimson.ViewsCrimson.Views  7 clr-namespace:Crimson.ViewModelsCrimson.ViewModels  H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls     Crimson.Views.GameWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:Crimson.Views     6	viewmodel clr-namespace:Crimson.ViewModels     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions    � Title$  Выбор макроса��$	��220��$	��420�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�$��Candara)� � DataContext ��    mainViewModelLocator �� Source# [   �� Path$ GameWindowVM�.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Closing��.  (System.Windows.Interactivity.TriggerBase   Actions. >  8Microsoft.Expression.Interactivity.Core.CallMethodAction  	   
MethodName$	 MetroWindow_Closing��
   TargetObject
 �� .��� $��5q� � ColumnDefinitions �� $��1.25* ���  � RowDefinitions �� $
��1.1* ��� $
��0.6* ��� $
��1.1* ��� $��1.25* �.+��� $��0��$��0�� �� Orientation$ 
Horizontal=�$��5q�.+��� $��Макрос:��
���<��  
MetroLabel#��[ $��14(�$��Center=���   MetroComboBox#��[  �� DisplayMemberPath$
 Name��$	��150��
���<��
���<��+  %MahApps.Metro.Controls.ControlsHelper   FocusBorderBrush
 �<��$��2q����� *Macros+ �� SelectedIndex �� *SelectedMacroIndex+�� $ 
Horizontal=�$��1��y��� *ScopeVisibility+.+��� $��Прицел:��
���<��#��[ $��14(�$��Center=��� #��[ $
 Name��$	��100��
���<��
���<��
 �<��$��2q����� *Scopes+ �� *SelectedScopeIndex+�� $��1��$��2��$ 
Horizontal=�$��5,0,0,0q�y��� *ShootingModeVisibility+.+��� $"��Режим стрельбы:��
���<��#��[ $��14(�$��Center=�	� $
��Auto��$��3q�$��14(�
���<��  MetroRadioButton#��[  d� 	IsChecked �� *AutoChecked+	� $��Single��$��3q�$��14(�
���<��#��[  �� *SingleChecked+�� $ 
Horizontal=�$��2��$��2��.+��� $��52��$��52��  	AlertIcon#��[ �� $
��Wrap=�$��14(�
���<��$	��353���� ��� *FirstComment+ �� Mode$ OneWay=��� �� ��� *SecondComment+$ OneWay=��� �� ��� *ThirdComment+$ OneWay=�� $��3��$��2�� �� $
��0.5* ��� .+��� $ 
Horizontal=�$	��100��.+��� $��Статус:��
�������$��2q��� $��2q�$��55������  �� 
TargetType" ��.���  �� Property � �� �� Value$ Неактивен����  � ��
 �  �� �� Triggers ��  �� Binding �� *IsMacroEnabled+ �� Value true.a���  � ��$ Активен����  � ��
 � � �d� $��1��$	��100��$��Center=�$��2q�$��14(�$��2q����� *ActivateMacros+���� *	IsChecked+ �� RelativeSource �� *Self+ �� *IsMacroEnabled+���� " d�  MetroToggleButton �� BasedOn# [ .���  � �� �	#FF252525��  � ��
 �<����  � ��$ Включить����  � ��
 �<�� P�  P� Property �@d�	IsChecked P� Value$
 TrueY�. ���  � �� �	#FF252525��  � ��
 � � ���  � ��$ Выключить����  � ��
 � � �P�  �@d�	IsChecked$ FalseY�. ���  � ��
 �<��