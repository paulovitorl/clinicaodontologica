   M S B A M L   `   `   `  ����X  TXceed.Wpf.Toolkit, Version=4.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  5   	   N JClinicaOdontologica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ClinicaOdontologicaClinicaOdontologica 5   	   (   "ClinicaOdontologica.ConsultaWindow   5   
   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   NwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6T   3local!clr-namespace:ClinicaOdontologica     5   	     � WindowStartupLocation$  CenterScreen=�5   
    � Title$ ConsultaWindow��5   	   $	��439��6    $	��596��6-   .��5	      � $��0,0,10,4q�6   .+�5
   
   �� $��	Paciente:��6   $
��Left=�6$   $��	54,38,0,0q�6?   $	��Top=�6R   $��64��6j   �� 5   
   -   5         ��Name$ 
IdPaciente��5      $
��Left=�6'   $��
123,41,0,0q�6B   $	��Top=�6V   $	��415��6n   �� 5   
   $��	Dentista:��6   $
��Left=�6$   $��	54,68,0,0q�6?   $	��Top=�6R   $��64��6j   �� 5   
   -   5        $ 
IdDentista��5      $
��Left=�6'   $��
123,71,0,0q�6B   $	��Top=�6V   $	��415��6n   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DataConsulta��5      $
��Left=�6+   $��123,127,0,0q�6F   $	��Top=�6[   &    Xceed.Wpf.Toolkit.DateTimePicker  5   
   -   5          Name$ HoraConsulta��5   !   &    Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ 	ShortTime=�67   �   �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, System.Runtime, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value	 13:306J   $
��Left=�6X   $��123,158,0,0q�6s   $	��Top=�6�   $��76��6�   $��Right=�6�   #   Xceed.Wpf.Toolkit.RichTextBox  5   
   -   5          Name$ 
Observacao��5      $
��Left=�63   $��123,190,0,0q�6N   $	��Top=�6c   $	��415��6{   $��Right=�6�   $	��124��6�   �� 5   
   $��Data:��6   $
��Left=�6    $��
72,125,0,0q�6;   $	��Top=�6O   $��38��6g   �� 5   
   $��Hora:��6   $
��Left=�6    $��
71,154,0,0q�6;   $	��Top=�6O   $��38��6g   �� 5   
   $��	Serviço:��6   $
��Left=�6#   $��	58,96,0,0q�6>   $	��Top=�6Q   $��55��6i   �� 5   
   -   5        $ 	IdServico��5      $
��Left=�6&   $��
123,99,0,0q�6A   $	��Top=�6U   $	��415��6m   �� 5   
   $��Observação:��6   $
��Left=�6&   $��
36,190,0,0q�6A   $	��Top=�6U   $��76��6m   �� 5   
   -   5        $��Salvar��5      $
��Left=�6"   $��345,355,0,0q�6=   $	��Top=�6R   $��33��6j   $��94��6v   6�   �� 5   
   -   5        $
��Sair��5      $
��Left=�6    $��444,355,0,0q�6;   $	��Top=�6P   $��33��6h   $��94��6t   6   5      5      