   M S B A M L   `   `   `  ���� N  JClinicaOdontologica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ClinicaOdontologicaClinicaOdontologica  %    ClinicaOdontologica.ServicoList   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:ClinicaOdontologica       � WindowStartupLocation$  CenterScreen=� � Title$ ServicoList��$	��316��$	��617��.��� $��	0,0,10,17q�.+�&   System.Windows.Controls.DataGrid  -     Name$ DataGridServicoList��   
IsReadOnly$
 True��   SelectionMode$ Single=�   AutoGenerateColumns$ False��$��
10,10,0,97q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� 
 �� Path$
 Id�  $
 Nome��$	 400 	 �� $

 Nome�  $ Preço��$	 100 	 �� $
 Valor��� -   $��	Adicionar��$
��Left=�$��295,214,0,0q�$	��Top=�$��36��$��91���� -   $��Editar��$
��Left=�$��391,214,0,0q�$	��Top=�$��36��$��91���� -   $��Remover��$
��Left=�$��487,214,0,0q�$	��Top=�$��36��$��91��