   M S B A M L   `   `   `  ���� N  JClinicaOdontologica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ClinicaOdontologicaClinicaOdontologica  (    "ClinicaOdontologica.PacienteWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:ClinicaOdontologica       � WindowStartupLocation$  CenterScreen=� � Title$ Cadastro de Paciente��$	��608��$	��621��.��� .+��� -    ��Name$	 Cep��$
��Left=�$��166,297,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��120�� �� 	MaxLength$ 8��4  .System.Windows.Automation.AutomationProperties   IsRequiredForForm$
 True���� $
��CEP:��$
��Left=�$��113,293,0,0q�$	��Top=�$��Normal"�
���   �$��33���� -   $
��Left=�$��166,345,0,0q�$
 Wrap=�$	��Top=�$	��120���� $��	Cidade:
��$
��Left=�$��
98,341,0,0q�$	��Top=�$��Normal"�
���   �$��50��$��25���� -   $ Cidade��$
��Left=�$��166,345,0,0q�$
 Wrap=�$	��Top=�$	��247���� -   $ Bairro��$
��Left=�$��166,370,0,0q�$
 Wrap=�$	��Top=�$	��247���� $��	Bairro:
��$
��Left=�$��105,366,0,0q�$	��Top=�$��Normal"�
���   �$��43��$��26���� -   $ 
Logradouro��$
��Left=�$��166,396,0,0q�$
 Wrap=�$	��Top=�$	��418���� $��Logradouro:
��$
��Left=�$��
74,394,0,0q�$	��Top=�$��Normal"�
���   �$��74��$��24���� -   $ 
Referencia��$
��Left=�$��166,422,0,0q�$
 Wrap=�$	��Top=�$	��418���� $��Referência:
��$
��Left=�$��
78,418,0,0q�$	��Top=�$��Normal"�
���   �$��25���� -   $ Numero��$
��Left=�$��166,447,0,0q�$
 Wrap=�$	��Top=�$	��120��$ 8���� $��	Numero:
��$
��Left=�$��
90,443,0,0q�$	��Top=�$��Normal"�
���   �$��25���� -   $ Complemento��$
��Left=�$��166,472,0,0q�$
 Wrap=�$	��Top=�$	��247���� $��Complemento:
��$
��Left=�$��
61,469,0,0q�$	��Top=�$��Normal"�
���   �$��87��$��23���� -	   $��Salvar��$
��Left=�$��391,523,0,0q�$	��Top=�$��33��$��94���� -
   $
��Sair��$
��Left=�$��490,523,0,0q�$	��Top=�$��33��$��94���� $��Endereço
��$
��Left=�$��
21,248,0,0q�$	��Top=�$	��183��$��20(�$��36���� -   $ NumProntuario��$
��Left=�$��
160,86,0,0q�$
 Wrap=�$	��Top=�$	��424���� $��Número do prontuário:��$
��Left=�$��	10,82,0,0q�$	��Top=�$��Normal"�
���   �$��24��$	��136���� -   $	 Cpf��$
��Left=�$��160,110,0,0q�$
 Wrap=�$	��Top=�$	��120��$ 11���� $��CPF:
��$
��Left=�$��109,107,0,0q�$	��Top=�$��Normal"�
���   �$��23���� $��Data de Nascimento:��$
��Left=�$��
21,131,0,0q�$	��Top=�$	��125���� $��Sexo:��$
��Left=�$��105,161,0,0q�$	��Top=�$��41���� -   $ Telefone��$
��Left=�$��160,193,0,0q�$
 Wrap=�$	��Top=�$	��424��$ 16���� $��	Telefone:��$
��Left=�$��
90,189,0,0q�$	��Top=�$��56���� -   $ Email��$
��Left=�$��160,216,0,0q�$
 Wrap=�$	��Top=�$	��424���� $��E-mail:��$
��Left=�$��100,212,0,0q�$	��Top=�$��46��$��28���� $��Dados Cadastrais��$
��Left=�$��	17,16,0,0q�$	��Top=�$	��183��$��20(�$��39���� -   $
 Nome��$
��Left=�$��
160,60,0,0q�$
 Wrap=�$	��Top=�$	��424���� $��Nome:
��$
��Left=�$��	96,56,0,0q�$	��Top=�$��Normal"�
���   �$��26��(  "System.Windows.Controls.DatePicker  -     Name$ DataNascimento��$
��Left=�$��160,134,0,0q�$	��Top=��� -    ��Name$
 Sexo�� �� SelectedValuePath$	 Tag��$
��Left=�$��160,164,0,0q�$	��Top=�$	��120��.@��� 
	 � Tag$	 M��.��	Masculino�� $	 F��.��
Feminino�� -   $ Estado��$	 Tag��$
��Left=�$��166,320,0,0q�$	��Top=�$	��120��.@��� $	 AC��$��	Acre - AC���� $	 AL��$��Alagoas - AL���� $	 AP��$��Amapá - AP���� $	 AM��$��Amazonas - AM���� $	 BA��$��
Bahia - BA���� $	 CE��$��Ceará - CE���� $	 DF��$��Distrito Federal - DF���� $	 ES��$��Espírito Santo - ES���� $	 GO��$��Goiás - GO���� $	 MA��$��Maranhão - MA���� $	 MT��$��Mato Grosso - MT���� $	 MS��$��Mato Grosso do Sul - MS���� $	 MG��$��Minas Gerais - MG���� $	 PA��$��
Pará - PA���� $	 PB��$��Paraíba - PB���� $	 PR��$��Paraná - PR���� $	 PE��$��Pernambuco - PE���� $	 PI��$��Piauí - PI���� $	 RJ��$��Rio de Janeiro - RJ���� $	 RN��$��Rio Grande do Norte - RN���� $	 RS��$��Rio Grande do Sul - RS���� $	 RO��$��Rondônia - RO���� $	 RR��$��Roraima - RR���� $	 SC��$��Santa Catarina - SC���� $	 SP��$��São Paulo - SP���� $	 SE��$��Sergipe - SE���� $	 TO��$��Tocantins - TO���� $��Estado:
��$
��Left=�$��101,318,0,0q�$	��Top=�$��Normal"�
���   �$��26��$��48��