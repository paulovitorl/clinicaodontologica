   M S B A M L   `   `   `  ���� N  JClinicaOdontologica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ClinicaOdontologicaClinicaOdontologica  ,    &ClinicaOdontologica.EditDentistaWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:ClinicaOdontologica       � WindowStartupLocation$  CenterScreen=� � Title$ Editar dentista��$	��690��$	��621��.��� $	��650��$	��Top=�.+��� -    ��Name$	 Cep��$
��Left=�$��166,362,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��120�� �� 	MaxLength$ 8��4  .System.Windows.Automation.AutomationProperties   IsRequiredForForm$
 True���� $
��CEP:��$
��Left=�$��113,358,0,0q�$	��Top=�$��Normal"�
���   �$��33���� $
��Left=�$��166,409,0,0q�$
 Wrap=�$	��Top=�$	��120���� $��	Cidade:
��$
��Left=�$��
98,405,0,0q�$	��Top=�$��Normal"�
���   �$��50��$��25���� -   $ Cidade��$
��Left=�$��166,409,0,0q�$
 Wrap=�$	��Top=�$	��247���� -   $ Bairro��$
��Left=�$��166,434,0,0q�$
 Wrap=�$	��Top=�$	��247���� $��	Bairro:
��$
��Left=�$��105,430,0,0q�$	��Top=�$��Normal"�
���   �$��43��$��26���� -   $ 
Logradouro��$
��Left=�$��166,460,0,0q�$
 Wrap=�$	��Top=�$	��418���� $��Logradouro:
��$
��Left=�$��
74,458,0,0q�$	��Top=�$��Normal"�
���   �$��74��$��24���� -   $ 
Referencia��$
��Left=�$��166,486,0,0q�$
 Wrap=�$	��Top=�$	��418���� $��Referência:
��$
��Left=�$��
78,482,0,0q�$	��Top=�$��Normal"�
���   �$��25���� -   $ Numero��$
��Left=�$��166,511,0,0q�$
 Wrap=�$	��Top=�$	��120��$ 8���� $��	Numero:
��$
��Left=�$��
90,507,0,0q�$	��Top=�$��Normal"�
���   �$��25���� -   $ Complemento��$
��Left=�$��166,536,0,0q�$
 Wrap=�$	��Top=�$	��247���� $��Complemento:
��$
��Left=�$��
61,533,0,0q�$	��Top=�$��Normal"�
���   �$��87��$��23���� -   $��Salvar��$
��Left=�$��391,599,0,0q�$	��Top=�$��33��$��94���� -	   $��Fechar��$
��Left=�$��490,599,0,0q�$	��Top=�$��33��$��94���� $��Endereço
��$
��Left=�$��
21,333,0,0q�$	��Top=�$	��183��$��20(�$��36���� -
   $	 Cpf��$
��Left=�$��
160,86,0,0q�$
 Wrap=�$	��Top=�$	��120��$ 11���� $��CPF:
��$
��Left=�$��
112,83,0,0q�$	��Top=�$��Normal"�
���   �$��23���� $��Data de Nascimento:��$
��Left=�$��
25,129,0,0q�$	��Top=�$	��125���� $��Sexo:��$
��Left=�$��108,159,0,0q�$	��Top=�$��41���� -   $ Telefone��$
��Left=�$��160,191,0,0q�$
 Wrap=�$	��Top=�$	��424��$ 16���� $��	Telefone:��$
��Left=�$��
90,187,0,0q�$	��Top=�$��56���� -   $ Email��$
��Left=�$��160,214,0,0q�$
 Wrap=�$	��Top=�$	��424���� $��E-mail:��$
��Left=�$��100,210,0,0q�$	��Top=�$��46��$��28���� $��Dados Cadastrais��$
��Left=�$��	17,16,0,0q�$	��Top=�$	��183��$��20(�$��39���� -   $
 Nome��$
��Left=�$��
160,60,0,0q�$
 Wrap=�$	��Top=�$	��424���� $��Nome:
��$
��Left=�$��	99,56,0,0q�$	��Top=�$��Normal"�
���   �$��26��(  "System.Windows.Controls.DatePicker  -     Name$ DataNascimento��$
��Left=�$��160,132,0,0q�$	��Top=��� -    ��Name$
 Sexo�� �� SelectedValuePath$	 Tag��$
��Left=�$��160,162,0,0q�$	��Top=�$	��120��.@��� 
	 � Tag$	 M��.��	Masculino�� $	 F��.��
Feminino�� -   $ Estado��$	 Tag��$
��Left=�$��166,384,0,0q�$	��Top=�$	��120��.@��� $	 AC��$��	Acre - AC���� $	 AL��$��Alagoas - AL���� $	 AP��$��Amapá - AP���� $	 AM��$��Amazonas - AM���� $	 BA��$��
Bahia - BA���� $	 CE��$��Ceará - CE���� $	 DF��$��Distrito Federal - DF���� $	 ES��$��Espírito Santo - ES���� $	 GO��$��Goiás - GO���� $	 MA��$��Maranhão - MA���� $	 MT��$��Mato Grosso - MT���� $	 MS��$��Mato Grosso do Sul - MS���� $	 MG��$��Minas Gerais - MG���� $	 PA��$��
Pará - PA���� $	 PB��$��Paraíba - PB���� $	 PR��$��Paraná - PR���� $	 PE��$��Pernambuco - PE���� $	 PI��$��Piauí - PI���� $	 RJ��$��Rio de Janeiro - RJ���� $	 RN��$��Rio Grande do Norte - RN���� $	 RS��$��Rio Grande do Sul - RS���� $	 RO��$��Rondônia - RO���� $	 RR��$��Roraima - RR���� $	 SC��$��Santa Catarina - SC���� $	 SP��$��São Paulo - SP���� $	 SE��$��Sergipe - SE���� $	 TO��$��Tocantins - TO���� $��Estado:
��$
��Left=�$��101,382,0,0q�$	��Top=�$��Normal"�
���   �$��26��$��48���� $��	Salário:��$
��Left=�$��
98,260,0,0q�$	��Top=�$��48���� -   $ Salario��$
��Left=�$��160,265,0,0q�$
 Wrap=�$	��Top=�$	��424���� $��Situação:��$
��Left=�$��
89,286,0,0q�$	��Top=�$��58���� -   $ Situacao��$	 Tag��$
��Left=�$��160,290,0,0q�$	��Top=�$	��120��.@��� $	 1��$��Ativo���� $	 0��$��
Não Ativo���� -   $	 Cro��$
��Left=�$��160,109,0,0q�$
 Wrap=�$	��Top=�$	��253��$ 11���� $��CRO:
��$
��Left=�$��109,106,0,0q�$	��Top=�$��Normal"�
���   �$��23���� $��Cargo:��$
��Left=�$��102,235,0,0q�$	��Top=�$��45���� -   $ Funcao��
 �� SelectedIndex$
 0�� �� 
IsReadOnly$
 True��$
��Left=�$��160,238,0,0q�$	��Top=�$	��120������  �� EndPoint$	 0,1&�.���  � Color$ 	#FFF0F0F0�� � Offset$ 0.996Q�� $ 	#FFA4A4A4��$ 1Q�� $ 	#FF838383��$ 0Q�.@��� $	 Dentista��$��Dentista��