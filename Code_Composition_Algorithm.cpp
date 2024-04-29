#include<iostream>
#include<cstring>
#include<ctime>
#include<cstdlib>
using namespace std;

/* 화음 규칙 1도 ~ 6도
    1도 도미솔 / 2도 레파라 / 3도 미솔시 / 4도 파라도 / 5도 솔시레 / 6도 라도미

    1. 1 -> 아무곳에든
    2. 2 -> 4, 5
    3. 3 -> 2
    4. 4 -> 2, 5
    5. 5 -> 1, 2
    6. 6 -> 2, 4, 5
    7. 1, 5, 8 마디 == 1
*/

int code_rule(int code);
int extra_rule(int code);
void code_print(int code);

int main(void){
    srand((unsigned)time(NULL));
    int code[8];
    //이하 고정 코드
    // ********************* //
    code[0] = 1;
    code[3] = 5; 
    code[4] = 1;
    code[6] = 5; 
    code[7] = 1;
    // ********************* //

    // 0번 = 1
    code[1] = code_rule(code[0]);
    code[2] = extra_rule(code[1]);
    // 3번 = 5
    // 4번 = 1
    code[5] = extra_rule(code[4]);
    // 6번 = 5
    // 7번 = 1

    for(int i = 0; i < 7+1; i++)
        cout << code[i] << " ";
    cout << endl;
    for(int i = 0; i< 7+1; i++)
        code_print(code[i]);
    return 0;
}

int code_rule(int code){
    if(code == 1) // 1
        return rand() % 6 + 1;
    else if(code == 2){ // 2
        int sub = rand() % 2;
        if(sub == 0)
            return 4;
        else
            return 5;
    }
    else if(code == 3) // 3
        return 2;
    else if(code == 4){ // 4
        int sub = rand() % 2;
        if(sub == 0)
            return 2;
        else
            return 5;
    }
    else if(code == 5){
        int sub = rand() % 2;
        if(sub == 0)
            return 1;
        else
            return 2;
    }
    else if(code == 6){
        int sub = rand() % 3;
        if(sub == 0)
            return 2;
        else if(sub == 1)
            return 4;
        else if(sub == 2)
            return 5;
    }
    return 0;
}
int extra_rule(int code){ // 3번 마디 특수 코드
    if(code == 1){
        int sub = rand() % 3;
        if(sub == 0)
            return 2;
        else if(sub == 1)
            return 4;
        else if(sub == 2)
            return 6;
    }
    else if(code == 2)
        return 4;
    else if(code == 3)
        return 2;
    else if(code == 4)
        return 2;
    else if(code == 5){
        int sub = rand() % 2;
        if(sub == 0)
            return 1;
        else
            return 2;
    }
    else if(code == 6){
        int sub = rand() % 2;
        if(sub == 0)
            return 2;
        else
            return 4;
    }
    return 0;
}

void code_print(int code){
    if(code == 1)
        cout << "C" << " ";
    else if(code == 2)
        cout << "D" << " ";
    else if(code == 3)
        cout << "E" << " ";
    else if(code == 4)
        cout << "F" << " ";
    else if(code == 5)
        cout << "G" << " ";
    else if(code == 6)
        cout << "A" << " ";
}