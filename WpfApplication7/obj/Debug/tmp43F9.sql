CREATE TABLE [dbo].[StudentEntities] (
    [Stu_id] [nvarchar](128) NOT NULL,
    [Stu_name] [nvarchar](max) NOT NULL,
    [Stu_class] [nvarchar](max) NOT NULL,
    [Stu_age] [int] NOT NULL,
    [Stu_gender] [int] NOT NULL,
    CONSTRAINT [PK_dbo.StudentEntities] PRIMARY KEY ([Stu_id])
)
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201908210256572_InitModel', N'WpfApplication7.Migrations.Configuration',  0x1F8B0800000000000400CD57CD6EE33610BE17E83B103CB540D6CCCFA16920EF22759222E83A59ACB2DB63414B2385287F54920AEC67EBA18FD457E8E8DFA6627B9DB4D8C2176B38F3716634F3CDE8EF3FFF8ADE2D95244F609D307A4A4F26C794804E4C2A743EA5A5CFDE9CD3776FBFFD26BA4ED5927CEEF4CE2A3DB4D46E4A1FBD2F2E1873C92328EE264A24D63893F9496214E3A961A7C7C73FB29313060841118B90E863A9BD50503FE0E3CCE8040A5F7239372948D7CAF124AE51C91D57E00A9EC094FE5A6497452145C23DBAF203259752707423069951C2B536BE3EB9F8E420F6D6E83C2E50C0E5C3AA00D4CBB874D03A7F31A87F691CC7A7551C6C30ECA092D279A30E043C396B13C342F317A597F689C3D45D638AFDAA8ABA4E1F66C8972968DFC829096FBC98495B698F523CD9303C22C1F1515F16583DD5EF88CC4AE94B0B530DA5B75C1E910FE502F57F81D583F91DF4549752AEFB8ADEE2D98600451FAC29C0FAD547C886087E1329256CD39685C6BD6960D784875581D54DC99C2FDF83CEFD23D6FDE93925376209692769CBE49316D80C68E46D898F77E8385F48E8CFD9DE7B35FEDB7133FEFDAF6E4E2477EEEB5CCDF33EE65BEDCF4E5F0492834EC11E8213B1A1E8C7AD802CE3B9D06037FBE18A7BFE4C37207DB40DE1DA446C3ADC60C6E05BB4F9AA9608C0940F5E34BC34095AEF399F7BEF06F2630DFB752CC9B6D06434E745812F778D365B09891BCE9CBD890FE713D560B0C43D432BBDB7FD4DDE587CEBC1295E8D9EDE08EBEA342F78F5C666A91AA9ADBF8B2D79EE6E1AA53BE48D21FB9D49F5BF31DB496D21D290C81B8C4DA15E1D26F42E859C3AB2AF271897DC6E21A49991A5D2BBC86D1F4A432F214E233D0CA9A58B10AA151F8655F77F88540B0FC3E9282084EAE463B48805AF2CAC0E362A8F60988405B7AB574395FEF6BE6783DE8CDA3ED9BFE78C1AA751A104D3F424D2BA6956CE839A540A93F80F399302E31D14E65C8B0C9C6F662EC5BE3E0FB6A5FFCFE6C29C4BE521EBCB57DB1EF413B7C923B7E3FDE195CB4107FC9DE2CBEF5F3FF05F0FB736C4455557AF1EE1FB510E1BE0E3D9B27B44075378DF946E1A6E4AD385C1081A9FD755EA51FFC2513EA68188AD7F144557E0443E40549F481A92AABF06D04EE75667A64B3E46BBEE51A712BC9B39789E62D22EAD17194F3C1E27E05CBD217EE6B244956BB580F456DF97BE28FDA573A01672637589D8EEFBEB7D65D3E7E8BEA89EDCBF1102BA293004B8D73F9542A6BDDF37CF54D51688AA7E7E0694D7BC851B32C2E5AB1EE9CEE82F046AD377054555EFDA3F802A2482B97B1DF32778896FB87EBE879C27AB8ECDB783EC7F119B698FAE04CF2D57AEC518ECAB0F7D567DE9BFFD07B690D3691B100000 , N'6.2.0-61023')

