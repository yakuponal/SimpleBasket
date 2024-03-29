
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [Address]) VALUES (1, N'Yakup', N'Önal', N'yakuponall@hotmail.com', N'Kayseri')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [Address]) VALUES (2, N'Adem', N'Ayvacık', N'adem@gmail.com', N'İstanbul')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [Address]) VALUES (3, N'Kazım', N'Balta', N'kazım@gmail.com', N'Ankara')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [Address]) VALUES (4, N'Ayla', N'Baytın', N'ayla@gmail.com', N'Ankara')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [Address]) VALUES (5, N'Hüner', N'Berk', N'hunar@hotmail.com', N'İzmir')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [Address]) VALUES (6, N'Yaprak', N'Canbağı', N'yaprak@gmail.com', N'Bursa')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [ProductName], [CreateDate]) VALUES (1, N'iPhone 12 Mini', CAST(N'2021-01-09T01:35:37.733' AS DateTime))
INSERT [dbo].[Product] ([ProductId], [ProductName], [CreateDate]) VALUES (2, N'iPhone 11 Pro Max', CAST(N'2021-01-09T01:35:37.770' AS DateTime))
INSERT [dbo].[Product] ([ProductId], [ProductName], [CreateDate]) VALUES (3, N'Apple Watch', CAST(N'2021-01-09T01:35:37.803' AS DateTime))
INSERT [dbo].[Product] ([ProductId], [ProductName], [CreateDate]) VALUES (4, N'Apple MacBook Pro', CAST(N'2021-01-09T01:35:37.887' AS DateTime))
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductDetail] ON 

INSERT [dbo].[ProductDetail] ([ProductDetailId], [ProductId], [ProductDetailName], [Description], [Price], [Stock], [CreateDate]) VALUES (1, 1, N'iPhone 12 Mini 128 GB Siyah', NULL, CAST(10499.00 AS Decimal(18, 2)), 500, CAST(N'2021-01-09T01:37:40.403' AS DateTime))
INSERT [dbo].[ProductDetail] ([ProductDetailId], [ProductId], [ProductDetailName], [Description], [Price], [Stock], [CreateDate]) VALUES (2, 1, N'iPhone 12 Mini 256 GB Kırmızı', NULL, CAST(12199.00 AS Decimal(18, 2)), 300, CAST(N'2021-01-09T01:38:12.870' AS DateTime))
INSERT [dbo].[ProductDetail] ([ProductDetailId], [ProductId], [ProductDetailName], [Description], [Price], [Stock], [CreateDate]) VALUES (4, 2, N'iPhone 11 Pro Max 128 GB Siyah', NULL, CAST(9499.90 AS Decimal(18, 2)), 200, CAST(N'2021-01-09T01:51:20.350' AS DateTime))
INSERT [dbo].[ProductDetail] ([ProductDetailId], [ProductId], [ProductDetailName], [Description], [Price], [Stock], [CreateDate]) VALUES (5, 3, N'Apple Watch Seri 6', NULL, CAST(2499.00 AS Decimal(18, 2)), 900, CAST(N'2021-01-09T01:51:40.410' AS DateTime))
INSERT [dbo].[ProductDetail] ([ProductDetailId], [ProductId], [ProductDetailName], [Description], [Price], [Stock], [CreateDate]) VALUES (6, 4, N'Apple MacBook Pro', NULL, CAST(24599.00 AS Decimal(18, 2)), 500, CAST(N'2021-01-09T01:52:03.513' AS DateTime))
SET IDENTITY_INSERT [dbo].[ProductDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Basket] ON 

INSERT [dbo].[Basket] ([BasketId], [CustomerId], [ProductDetailId], [Quantity], [CreateDate]) VALUES (1, 1, 2, 1, CAST(N'2021-01-09T01:41:24.650' AS DateTime))
INSERT [dbo].[Basket] ([BasketId], [CustomerId], [ProductDetailId], [Quantity], [CreateDate]) VALUES (2, 2, 1, 2, CAST(N'2021-01-09T01:41:40.770' AS DateTime))
SET IDENTITY_INSERT [dbo].[Basket] OFF
GO
SET IDENTITY_INSERT [dbo].[OptionGroup] ON 

INSERT [dbo].[OptionGroup] ([OptionGroupId], [OptionGroupName]) VALUES (1, N'Hafıza')
INSERT [dbo].[OptionGroup] ([OptionGroupId], [OptionGroupName]) VALUES (2, N'Renk')
SET IDENTITY_INSERT [dbo].[OptionGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[Option] ON 

INSERT [dbo].[Option] ([OptionId], [OptionGroupId], [OptionName]) VALUES (1, 1, N'64 GB')
INSERT [dbo].[Option] ([OptionId], [OptionGroupId], [OptionName]) VALUES (2, 1, N'128 GB')
INSERT [dbo].[Option] ([OptionId], [OptionGroupId], [OptionName]) VALUES (3, 1, N'256 GB')
INSERT [dbo].[Option] ([OptionId], [OptionGroupId], [OptionName]) VALUES (4, 2, N'Siyah')
INSERT [dbo].[Option] ([OptionId], [OptionGroupId], [OptionName]) VALUES (5, 2, N'Beyaz')
INSERT [dbo].[Option] ([OptionId], [OptionGroupId], [OptionName]) VALUES (6, 2, N'Kırmızı')
SET IDENTITY_INSERT [dbo].[Option] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductOption] ON 

INSERT [dbo].[ProductOption] ([ProductOptionId], [ProductDetailId], [OptionId]) VALUES (1, 1, 2)
INSERT [dbo].[ProductOption] ([ProductOptionId], [ProductDetailId], [OptionId]) VALUES (2, 1, 4)
INSERT [dbo].[ProductOption] ([ProductOptionId], [ProductDetailId], [OptionId]) VALUES (3, 2, 3)
INSERT [dbo].[ProductOption] ([ProductOptionId], [ProductDetailId], [OptionId]) VALUES (4, 2, 6)
INSERT [dbo].[ProductOption] ([ProductOptionId], [ProductDetailId], [OptionId]) VALUES (5, 4, 2)
INSERT [dbo].[ProductOption] ([ProductOptionId], [ProductDetailId], [OptionId]) VALUES (6, 4, 4)
SET IDENTITY_INSERT [dbo].[ProductOption] OFF
GO
