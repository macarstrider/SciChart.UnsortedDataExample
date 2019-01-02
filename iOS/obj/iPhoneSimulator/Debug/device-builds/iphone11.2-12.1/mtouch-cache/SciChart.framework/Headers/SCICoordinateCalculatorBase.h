//******************************************************************************
// SCICHART® Copyright SciChart Ltd. 2011-2018. All rights reserved.
//
// Web: http://www.scichart.com
// Support: support@scichart.com
// Sales:   sales@scichart.com
//
// SCICoordinateCalculatorBase.h is part of SCICHART®, High Performance Scientific Charts
// For full terms and conditions of the license, see http://www.scichart.com/scichart-eula/
//
// This source code is protected by international copyright law. Unauthorized
// reproduction, reverse-engineering, or distribution of all or any portion of
// this source code is strictly prohibited.
//
// This source code contains confidential and proprietary trade secrets of
// SciChart Ltd., and should at no time be copied, transferred, sold,
// distributed or made available without express written permission.
//******************************************************************************

/** \addtogroup CoordinateCalculators
 *  @{
 */

#import <Foundation/Foundation.h>
#import "SCICoordinateCalculatorProtocol.h"

typedef NS_OPTIONS(int, CoordinateCalculatorOptions) {
    CoordinateCalculator_XAxis = 1,
    CoordinateCalculator_YAxis = 2,
    CoordinateCalculator_CategoryAxis = 4,
    CoordinateCalculator_LogarithmicAxis = 8,
    CoordinateCalculator_HorizontalAxis = 16,
    CoordinateCalculator_Flipped = 32
};

@protocol SCIRangeProtocol;

@interface SCICoordinateCalculatorBase : NSObject <SCICoordinateCalculatorProtocol>

@property (nonatomic) BOOL isCategoryAxisCalculator;
@property (nonatomic) BOOL isLogarithmicAxisCalculator;
@property (nonatomic) BOOL isHorizontalAxisCalculator;
@property (nonatomic) BOOL isXAxisCalculator;
@property (nonatomic) BOOL hasFlippedCoordinates;
@property (nonatomic) BOOL isPolarAxisCalculator;

-(double) getCoordinateFromDate:(NSDate *)dataValue;
-(id<SCIRangeProtocol>) translateByPixels:(double)pixels InputRange:(id<SCIRangeProtocol>)inputRange;
-(double) getDataValueFrom:(double)pixelCoordinate;
-(id<SCIRangeProtocol>) translateByMinFraction:(double)minFraction MaxFraction:(double)maxFraction InputRange:(id<SCIRangeProtocol>)inputRange;
+(double) flip:(BOOL)flipCoords Coords:(double)coord WithViewPortDimension:(double)viewportDimension;

-(void)setCoordinatesOffset:(double)value;

@end

/** @}*/