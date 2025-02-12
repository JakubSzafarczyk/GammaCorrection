.data
multip real4 255.0
.code

gen_lut proc
movups xmm1, [rdx]
movups xmm0, [rcx]
movups [rsp+16], xmm0
fld real4 ptr [rsp+16]
movups [rsp+16], xmm1
fld real4 ptr[rsp+16]
fyl2x		;x*log2(y)
fld1		;st(0)=1
fld st(1)   ;st(0)=st(1), st(1)=1
fprem		;st(0)%st(1)
f2xm1		;2^st(0)-1
fadd		;st(0)++
fscale		;approx to power of 2
fstp REAL4 ptr [rsp+16]
fstp st(0)
movss xmm1, REAL4 ptr [rsp+16]
mulps xmm1, [multip]
movups [rdx], xmm1
movups [rcx], xmm0
ret
gen_lut endp

gamma_correction proc
    ; Parameters:
    ; rcx -> orginalImagePart (byte pointer)
    ; rdx -> lutTable (int pointer)
    ; r8  -> positionValue (int)
    ; r9  -> stopValue (int)

    push rbp                 ; Save the base pointer
    mov rbp, rsp             ; Establish stack frame

    ; Save r8 and r9 as they are non-volatile (callee-saved)
    push r8                  ; Save positionValue
    push r9                  ; Save stopValue

    ; Set up working registers
    mov r10, r8              ; r10 = positionValue
    mov r11, r9              ; r11 = stopValue
    mov r12, rcx             ; r12 = address of orginalImagePart
    mov r13, rdx             ; r13 = address of lutTable

GammaLoop:
    cmp r10, r11             ; Compare positionValue (r10) with stopValue (r11)
    jge EndLoop              ; Exit if positionValue >= stopValue

    ; Calculate index and perform gamma correction
    movzx r14, byte ptr [r12 + r10] ; Load orginalImagePart[positionValue] (byte to 64-bit)
    mov eax, dword ptr [r13 + r14 * 4] ; Look up lutTable value (int from r14)
    mov byte ptr [r12 + r10], al      ; Write back the corrected value to orginalImagePart

    inc r10                  ; Increment positionValue
    jmp GammaLoop            ; Repeat loop

EndLoop:
    pop r9                   ; Restore stopValue
    pop r8                   ; Restore positionValue
    pop rbp                  ; Restore base pointer
    ret                      ; Return to caller

gamma_correction endp

END