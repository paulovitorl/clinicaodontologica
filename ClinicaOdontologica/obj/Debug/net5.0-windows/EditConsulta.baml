   M S B A M L   `   `   `  ����X  TXceed.Wpf.Toolkit, Version=4.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  5   	   N JClinicaOdontologica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ClinicaOdontologicaClinicaOdontologica 5   	   &    ClinicaOdontologica.EditConsulta   5   
   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   NwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5   	   3local!clr-namespace:ClinicaOdontologica     5   	     � WindowStartupLocation$  CenterScreen=�5   
    � Title$ EditConsulta��5	   	   $	��500��6   $	��616��6+   .��5
      � $��0,0,10,4q�6   .+�5   
   �� $��	Paciente:��6   $
��Left=�6$   $��	87,78,0,0q�6?   $	��Top=�6R   $��64��6j   �� 5   
   -   5         ��Name$ 
IdPaciente��5      $
��Left=�6'   $��
156,81,0,0q�6B   $	��Top=�6V   $	��415��6n   �� 5   
   $��	Dentista:��6   $
��Left=�6$   $��
87,108,0,0q�6?   $	��Top=�6S   $��64��6k   �� 5   
   -   5        $ 
IdDentista��5      $
��Left=�6'   $��156,111,0,0q�6B   $	��Top=�6W   $	��415��6o   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DataConsulta��5      $
��Left=�6+   $��156,167,0,0q�6F   $	��Top=�6[   &    Xceed.Wpf.Toolkit.DateTimePicker  5   
   -   5          Name$ HoraConsulta��5   !   &    Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ 	ShortTime=�67   $
��Left=�6J   $��156,198,0,0q�6e   $	��Top=�6z   $��76��6�   $��Right=�6�   #   Xceed.Wpf.Toolkit.RichTextBox  5   
   -   5          Name$ 
Observacao��5      $
��Left=�63   $��156,230,0,0q�6N   $	��Top=�6c   $	��415��6{   $��Right=�6�   $	��124��6�   �� 5   
   $��Data:��6   $
��Left=�6    $��105,165,0,0q�6;   $	��Top=�6P   $��38��6h   �� 5   
   $��Hora:��6   $
��Left=�6    $��104,194,0,0q�6;   $	��Top=�6P   $��38��6h   �� 5   
   $��	Serviço:��6   $
��Left=�6#   $��
91,136,0,0q�6>   $	��Top=�6R   $��55��6j   �� 5   
   -   5        $ 	IdServico��5      $
��Left=�6&   $��156,139,0,0q�6A   $	��Top=�6V   $	��415��6n   �� 5   
   $��Observação:��6   $
��Left=�6&   $��69,0,0,0q�6A   $��Center=�6S   $��76��6n   �� 5   
   -   5        $��Salvar��5      $
��Left=�6"   $��376,406,0,0q�6=   $	��Top=�6R   $��33��6j   $��94��6v   6�   �� 5   
   -   5        $
��Sair��5      $
��Left=�6    $��475,406,0,0q�6;   $	��Top=�6P   $��33��6h   $��94��6t   6   �� 5   
   $��Situação da consulta:��6   $
��Left=�60   $��	24,46,0,0q�6K   $	��Top=�6^   $	��130��6v   �� 5   
   -	   5        $ Situacao��5      $
��Left=�6%   $��
156,50,0,0q�6@   $	��Top=�6T   $	��415��6l   5      5      