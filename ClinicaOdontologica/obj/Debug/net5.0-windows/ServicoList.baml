   M S B A M L   `   `   `  ����N  JClinicaOdontologica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ClinicaOdontologicaClinicaOdontologica  5   	   %    ClinicaOdontologica.ServicoList   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ClinicaOdontologica     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ ServicoList��5   	   $	��316��6   $	��617��6*   .��5	      � $��	0,0,10,17q�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridServicoList��5   Y      
IsReadOnly$
 True��6      SelectionMode$ Single=�6&      AutoGenerateColumns$ False��6=   $��
10,10,0,97q�6v      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6M   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� 
 �� Path$
 Id�6Z     5      $
 Nome��6%   $	 400 6Q   	 63   �� $

 Nome�6_     5      $ Preço��6%   $	 100 6S   	 64   �� $
 Valor�6a   5      �� 5   
   -   5        $��	Adicionar��5      $
��Left=�6%   $��295,214,0,0q�6@   $	��Top=�6U   $��36��6m   $��91��6y   6�   �� 5   
   -   5        $��Editar��5      $
��Left=�6"   $��391,214,0,0q�6=   $	��Top=�6R   $��36��6j   $��91��6v   6�   �� 5   
   -   5        $��Remover��5      $
��Left=�6#   $��487,214,0,0q�6>   $	��Top=�6S   $��36��6k   $��91��6w   6�   5      5      