   M S B A M L   `   `   `  ����B  >Crimson, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Crimson.ViewsCrimson.Views  5      7 clr-namespace:Crimson.ViewModelsCrimson.ViewModels  5      H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5          Crimson.Views.GameWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -localclr-namespace:Crimson.Views     5      6	viewmodel clr-namespace:Crimson.ViewModels     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5
        � Title$&   RUST - выбор макроса��5      $	��220��5      $	��420��6$    � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5      $��Candara)�5       � DataContext 5      ��    mainViewModelLocator �� Source# [   �� Path$ GameWindowVM�.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Closing��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      >  8Microsoft.Expression.Interactivity.Core.CallMethodAction  	   
MethodName$	 MetroWindow_Closing��5      
   TargetObject
 5      �� 5      5      .��5      � $��5q�6    � ColumnDefinitions 5   
   �� 5      $��1.25* �6   �� 5        � RowDefinitions 5#   
   �� 5$      $
��1.1* �6   �� 5%      �� 5&      $��1.25* �6   .+�5)   
   �� $��0��6   $��0��5*       �� Orientation$ 
Horizontal=�5+      $��5q�5,      .+�5/      �� $��Макрос:��6   
���<��  
MetroLabel#��[ 51      $��14(�52      $��Center=�53      �� 56        MetroComboBox#��[ 6    �� DisplayMemberPath$
 Name��58      $	��150��5:      
���<��
���<��+  %MahApps.Metro.Controls.ControlsHelper   FocusBorderBrush
 �<��$��2q�5>      ��57      �� *Macros+ �� SelectedIndex 59      �� *SelectedMacroIndex+5>      5A      �� 5C   
   $ 
Horizontal=�6   $��1��5D      .+�5E      �� $��5,5,5,5q�6     SquareButtonStyle#��[ 5F      $��Очистить��5H      
���<��$��14(�5J      
���<��$��2q�5L         ContentCharacterCasing$ Normal=�5M      $��80��5N      ��5G      �� *ClearMacros+5N      �� 5Q      $��1��6   $��5,5,5,5q�5R      #��[ 5S      $��Закрыть��5T      
���<��$��14(�5V      
���<��$��2q�5X      $ Normal=�5Y      $��80��5Z       5\        5]      $ Click��6%   . 5^        $	 Close��5`      
 5_      ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType(  "MahApps.Metro.Controls.MetroWindow"  5`      5b      5d      5e      �� 5f   
   $ 
Horizontal=�6   $��1��5g      $��2��5h      .+�5j      �� $��52��6   $��52��5k        	AlertIcon#��[ 5l      �� 5n      $
��Wrap=�5o      $��14(�5p      
���<��$	��353��5r      YWВ настройках игры установить один из вариантов:�� 5u      RP- Чувствительность мыши=1.0 и угол обзора(FOV)=75�� 5w      RP- Чувствительность мыши=0.8 и угол обзора(FOV)=905y      5z      � 5�   
   $��2��6   $��2��5�       5�      �� 5�      $
��0.5* �6    �� 5�      .+�5�      �� $ 
Horizontal=�6   $	��100��5�      .+�5�      �� $��Статус:��6   
�������$��2q�5�      �� 5�      $��2q�6   $��55��5�      ��5�      �� 5�       �� 
TargetType" ��6    .�5�      ��  �� Property � �� �� Value$ Неактивен��65   �� 5�       � ��
 �  ��6;    �� Triggers 5�      �� 5�   "    �� Binding 6.   �� *IsMacroEnabled+ �� Value true6Q   .a�5�   &   ��  � ��$ Активен��6=   �� 5�   &    � ��
 � � �6C   5�   #   5�      5�      5�      d� 5�      $��1��6   $	��100��5�      $��Center=�5�      $��2q�5�      $��14(�5�      $��2q�5�      ��5�      �� *ActivateMacros+��5�      �� *	IsChecked+ �� *Self+ d� 	IsChecked 5�      �� *IsMacroEnabled+��5�      �� 5�      " d�6     MetroToggleButton �� BasedOn# [ 66   .�5�      ��  � �� �	#FF25252567   �� 5�       � ��
 �<��67   �� 5�       � ��$ Включить��64   �� 5�       � ��
 �<��68    5�      P� 5�       P� Property �@d�	IsChecked P� Value$
 TrueY�6;   . �5�   "   ��  � �� �	#FF2525256?   �� 5�   "    � ��
 � � �6?   �� 5�   "    � ��$ Выключить��6<   �� 5�   "    � ��
 � � �6@   5�      P� 5�       �@d�	IsChecked$ FalseY�6;   . �5�   "   ��  � ��
 �<��6@   5�      5�      5�      5�      5�      5�      