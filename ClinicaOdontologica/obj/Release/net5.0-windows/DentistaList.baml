   M S B A M L   `   `   `  ���� N  JClinicaOdontologica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ClinicaOdontologicaClinicaOdontologica  &     ClinicaOdontologica.DentistaList   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:ClinicaOdontologica       � WindowStartupLocation$  CenterScreen=� � Title$ Lista de dentista��$	��367��$	��877��.��� $��0,0,10,7q�.+�&   System.Windows.Controls.DataGrid  -     Name$ DataGridDentistaList��   
IsReadOnly$
 True��   SelectionMode$ Single=�   AutoGenerateColumns$ False��$��
10,10,0,89q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� 
 �� Path$
 Id�  $
 Nome��$	 200 	 �� $

 Nome�  $	 CPF��$	 150 	 �� $	
 Cpf�  $	 Cro��$	 150 	 �� $	
 Cro�  $ Telefone��$	 150 	 �� $
 Contato.Telefone�  $ Situacao��$	 150 	 �� $
 Funcionario.Status��� -   $��	Adicionar��$
��Left=�$��553,279,0,0q�$	��Top=�$��36��$��91���� -   $��Editar��$
��Left=�$��649,279,0,0q�$	��Top=�$��36��$��91���� -   $��Remover��$
��Left=�$��745,279,0,0q�$	��Top=�$��36��$��91��