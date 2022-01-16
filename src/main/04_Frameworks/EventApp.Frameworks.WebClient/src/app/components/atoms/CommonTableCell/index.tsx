import React from "react";
import { CommmonTableCellContainer } from "./styles";

export type CommonTableCellProps = {
    value: string;
}

export const CommonTableCell: React.FC<CommonTableCellProps> = (props: CommonTableCellProps) => {
    return (
        <CommmonTableCellContainer>
            {props.value}
        </CommmonTableCellContainer>
    )
}