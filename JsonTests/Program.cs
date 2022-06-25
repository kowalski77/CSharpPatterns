using JsonTests;
using System.Text.Json;

//var point2d = new Point2D { X = 1, Y = 2 };
//var point2dAsText = JsonSerializer.Serialize(point2d);
//var point2dAgain = JsonSerializer.Deserialize<Point2D>(point2dAsText);

//Point2D point3d = new Point3D { X = 1, Y = 2, Z = 3 };
//var point3dsAsText = JsonSerializer.Serialize(point3d);
//var point3dAgain = JsonSerializer.Deserialize<Point3D>(point3dsAsText);

IIntegrationEvent productCreated = new ProductCreated(Guid.NewGuid(), Guid.NewGuid(), "name1", "description1", 10);
var productCreatedAsText = JsonSerializer.Serialize(productCreated, productCreated.GetType());
var productCreatedAsClass = JsonSerializer.Deserialize<ProductCreated>(productCreatedAsText);

Console.WriteLine("Hello, World!");
