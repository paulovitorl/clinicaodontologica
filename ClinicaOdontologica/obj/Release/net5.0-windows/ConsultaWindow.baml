   M S B A M L   `   `   `  ���� X  TXceed.Wpf.Toolkit, Version=4.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  N JClinicaOdontologica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ClinicaOdontologicaClinicaOdontologica (   "ClinicaOdontologica.ConsultaWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     NwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:ClinicaOdontologica       � WindowStartupLocation$  CenterScreen=� � Title$ ConsultaWindow��$	��439��$	��596��.��� $��0,0,10,4q�.+��� $��	Paciente:��$
��Left=�$��	54,38,0,0q�$	��Top=�$��64���� -    ��Name$ 
IdPaciente��$
��Left=�$��
123,41,0,0q�$	��Top=�$	��415���� $��	Dentista:��$
��Left=�$��	54,68,0,0q�$	��Top=�$��64���� -   $ 
IdDentista��$
��Left=�$��
123,71,0,0q�$	��Top=�$	��415��(  "System.Windows.Controls.DatePicker  -     Name$ DataConsulta��$
��Left=�$��123,127,0,0q�$	��Top=�&    Xceed.Wpf.Toolkit.DateTimePicker  -     Name$ HoraConsulta��&    Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ 	ShortTime=��   �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, System.Runtime, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value	 13:30$
��Left=�$��123,158,0,0q�$	��Top=�$��76��$��Right=�#   Xceed.Wpf.Toolkit.RichTextBox  -     Name$ 
Observacao��$
��Left=�$��123,190,0,0q�$	��Top=�$	��415��$��Right=�$	��124���� $��Data:��$
��Left=�$��
72,125,0,0q�$	��Top=�$��38���� $��Hora:��$
��Left=�$��
71,154,0,0q�$	��Top=�$��38���� $��	Serviço:��$
��Left=�$��	58,96,0,0q�$	��Top=�$��55���� -   $ 	IdServico��$
��Left=�$��
123,99,0,0q�$	��Top=�$	��415���� $��Observação:��$
��Left=�$��
36,190,0,0q�$	��Top=�$��76���� -   $��Salvar��$
��Left=�$��345,355,0,0q�$	��Top=�$��33��$��94���� -   $
��Sair��$
��Left=�$��444,355,0,0q�$	��Top=�$��33��$��94��