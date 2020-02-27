#include "stdafx.h"
#include <stdio.h>
#include <stdlib.h>

#pragma warning(disable:4996)


int main()
{
	unsigned char strData[30], strResult[30];
	int nNum = 0;
	int nLen = 0;
	int idx = 0;

	memset(strData, 0, sizeof(strData));
	memset(strResult, 0, sizeof(strResult));

	printf("Please input md5 encrypt value(Max size : 30 byte) : \r\n");

	scanf_s("%s", strData, sizeof(strData));

	while (strData[idx] != '\0')
	{
		idx++;
		nLen++;
	}

	md5_state_t state;
	md5_byte_t dataOut[16];

	memset(&state, 0, sizeof(md5_state_t));	

	md5_init(&state);
	md5_append(&state, (md5_byte_t *)strData, nLen);
	md5_finish(&state, dataOut);

	printf("MD5 Encrypt Result : \r\n");

	memcpy(&strResult, dataOut, 16);

	for (int i = 0; i < 16; i++)
	{
		printf("0x%02x ", strResult[i]);
	}

	scanf("%s", strData);

    return 0;
}
