   M S B A M L   `   `   `  ����K  GProjectForWizard, Version=1.0.0.2, Culture=neutral, PublicKeyToken=null3clr-namespace:ProjectForWizardProjectForWizard  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5   	   !    ProjectForWizard.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ProjectForWizard     5   	   Bcol2clr-namespace:System.Collections;assembly=mscorlib     5   	     � Title$  Wizard project��5	   	   $��476.5��6    $	��843��6/   $��476.5��6>    � WindowStartupLocation$ CenterScreen=�6P   $	��843��6u    � 	Resources 5         validationFailed �� Orientation��%�   &	        �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5      �� 
���  ��$��1q�6+   ._�5      �� 5      �� 5      $��1,0,0,0q�6   
���  ��$��14(�6>   $
��Bold"�6L   !6a   5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5       $��30 �6   �� 5!      $��30 �6   �� 5"      $��30 �6   �� 5#      $��30 �6   �� 5$      $��30 �6   �� 5%      $��30 �6   �� 5&      $��30 �6   �� 5'      $��30 �6   .+�5)   
   �� $#��Number of participent (items)��6   $��2q�68   $��0��6C   $��0��6P   �� 5*   
   -   5         ��Name$ txtNumberOfParticipent��5*      $��1��62   $��0��6?   $��5q�6O    =� ErrorTemplate# [  5+      .��6O   ��5,      �� 5-       �� Path$ numberOfPForError�6   	 �� ValidationRules	 5.      5  /System.Windows.Controls.DataErrorValidationRule  5/      51      .��52      53      �� 55   
   $��Number of test (items)��6   $��2q�61   $��2��6<   $��0��6I   �� 56   
   -   5        $ txtNumberOfTest��56      $��3��6+   $��0��68   $��5q�6H   # [  57      .��6O   ��58      �� 59      $ numberOfTForError�6   	 5:        5;      5=      .��5>      5?      �� 5A   
   $��Work schedule: ��6   $��2q�6*   $��4��65   �� 5B   
   $��From (hour): ��6   $��2q�6(   $��5��63   �� 5C   
   -   5        $��workTimeFrom��5C      $��5��6&   $��1��63   $��5q�6C   # [  6N   .��6�   ��5D      �� 5E      $ workTimeFromForError�6   	 5F        5G      5I      .��5J      5K      �� 5M   
   -   5        
 ��Name$
 optimizationCheckBox��5M       d� 	IsChecked$
 TrueY�61   $ ��Research work optimization��6D   $��4��6i   $��1��6v   $��Center=�6�   $��	10,0,10,0q�6�   �� 5N   
   $��Dinner (hour): ��6   $��2q�6*   $��6��65   $��0��6B   �� 5O   
   -   5        $��
dinnerTime��5O      $��6��6$   $��1��61   $��5q�6A   # [  6L   .��6�   ��5P      �� 5Q      $ dinnerTimeForError�6   	 5R        5S      5U      .��5V      5W      �� 5Y   
   $��To (hour): ��6   $��2q�6&   $��7��61   $��0��6>   �� 5Z   
   -   5        $��
workTimeTo��5Z      $��7��6$   $��1��61   $��5q�6A   # [  6L   .��6�   ��5[      �� 5\      $ workTimeToForError�6   	 5]        5^      5`      .��5a      5b      �� 5e   
   $*��$Rest interval between sets (minutes)��6   $��1��6?   $��2q�6O   �� 5f   
   -   5        $��breakRestTime��5f      $��1��6'   $��1��67   $��5q�6D   # [  6O   .��6�   ��5g      �� 5h      $ breakRestTimeForError�6   	 5i        5j      5l      .��5m      5n      �� 5q   
   $*��$Time interval for one test (minutes)��6   $��1��6?   $��2��6O   $��2q�6]   �� 5r   
   -   5        $��TimeForOneTest��5r      $��1��6(   $��3��68   $��5q�6E   # [  6P   .��6�   ��5s      �� 5t      $ TimeForOneTestForError�6   	 5u        5v      5x      .��5y      5z      �� 5|   
   -	   5        $��Submit��5|      $��10,10,10,-157q�67   $��8��6N   �� 5}   
   -
   5         ��Name$ Text_BeforeResearch��5}      $
��Bold"�6-   $��Result: ��6?   $��8��6R   $��10,10,10,-157q�6_   $��1��6v   �� 5~   
   -   5        $��
resultList��5~        persons#���  6%   $��2��6Y   $	��228��6i   $��
10,10,10,0q�6v   $��8��6�   $	��Top=�6�    �� View 5      �� 5�      .P�5�      ��  �� Width$	 105��6%    �� DisplayMemberBinding 61   �� $
 Name�.��6\   Name6b   �� 5�      $ 90��6%    60   �� $ StateOfMind�.��6b   State6i   �� 5�      $ 90��6%    60   �� $ BeforeSumOfTheAverageMark�.��6p   
First Mark6|   �� 5�      $ 90��6%    60   �� $ AfterSumOfTheAverageMark�.��6o   Second Mark6|   5�       5�      "  System.Collections.ArrayList��%   &	         5�      6    5�      5�      �� 5�   
   -   5        $ Text_AfterResearch��5�      $
��Bold"�6,   $��Result: ��6>   $��8��6Q   $��10,10,10,-157q�6^   $��2��6u   5�      5�      