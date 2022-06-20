using BenchmarkDotNet.Running;
using Comparisons;

// class
var coordinates = new Coordinates(10, 10);

// record
var coordinatesRecord = new CoordinatesRecord(10, 10););
var updatedCoordinatesRecord = coordinatesRecord with { Latitude = 20 };

// struct
var coordinatesStruct = new CoordinatesStruct(10, 10);
var coordinatesStruct2 = new CoordinatesStruct();

//var result = coordinatesStruct == coordinatesStruct2;
var result = coordinatesStruct.Equals(coordinatesStruct2);

// record struct
var coordinatesRecordStruct = new CoordinatesRecordStruct(10, 10);
var updatedCoordinatesRecordStruct = coordinatesRecordStruct with { Latitude = 20 };
var coordinatesRecordStruct2 = new CoordinatesRecordStruct();

var res = coordinatesRecordStruct == updatedCoordinatesRecordStruct;
var res2 = coordinatesRecordStruct.Equals(updatedCoordinatesRecordStruct);


//BenchmarkRunner.Run<TypesBenchy>();